using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace anagramme
{
    public partial class frmMain : Form
    {
        //Déclaration des variables
        Anagramme ana;
        List<Button> ListeLettre = new List<Button>();
        List<Button> btnClicke = new List<Button>();
        int nbLettreMise = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //Met le mot "anagramme" comme premier mot
            ana = new Anagramme("ANAGRAMME");
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;
            DessineLesBoutons(ana.MelangeMots("ANAGRAMME"));
            
        }

        public void DessineLesBoutons(string mot)
        {
            //Vider les listes lors d'un nouveau mot
            ListeLettre.Clear();
            btnClicke.Clear();
            nbLettreMise = 0;



            char[] lettres = mot.ToCharArray();
            //Générer les boutons par rapport au nombre de lettres dans le mot 
            gbxQuestion.Controls.Clear();

            gbxReponse.Controls.Clear();
            int x = 10;
            foreach (char lettre in lettres)
            {
                Button monBtn = new Button();

                monBtn.Size = new Size(80, 80);
                monBtn.Location = new Point(x, 25);
                monBtn.Text = lettre.ToString();
                monBtn.Click += monBtn_Click;
                monBtn.ForeColor = Color.Blue;
                monBtn.Font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);
                gbxQuestion.Controls.Add(monBtn);
                

                Button maLettre = new Button();
                maLettre.Size = new Size(80, 80);
                maLettre.Location = new Point(x, 25);
                maLettre.Text = "-";
                maLettre.Enabled = false;
                maLettre.Font = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold); 
                gbxReponse.Controls.Add(maLettre);
                ListeLettre.Add(maLettre);
                x += 90;
            }
           
        }

        void monBtn_Click(object sender, EventArgs e)
        {

            btnAnnuler.Enabled = true;
            //Met le texte du bouton cliqué dans le bouton de reponse 
            ListeLettre[nbLettreMise].Text = (sender as Button).Text;
            btnClicke.Add(sender as Button);
            (sender as Button).Enabled = false;
            nbLettreMise++;

            //Vérifie si c'est le bon mot 
            if (ana.Reponse.Length == nbLettreMise)
            {
                string solution = "";
                foreach (Button reponse in ListeLettre)
                {
                    if (reponse.Text != "-")
                        solution += reponse.Text;
                }
                ana.PropositionUtilisateur = solution.ToUpper();
                if (ana.isReponseOk())
                {
                    ana.NombreReponseJuste++;
                    btnAnnuler.Enabled = false;
                    btnReponse.Enabled = false;
                    lblReponse.Text = "Nombre de réponse juste : " + ana.NombreReponseJuste;
                    MessageBox.Show("Vous avez trouvé le mot", "Gagné");
                    
                }
                else
                {
                    MessageBox.Show("Faux", "Info");
                }
            }
        }


        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            
            btnAnnuler.Enabled = false;
            btnReponse.Enabled = true;
            btnSuivant.Enabled = true;
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;

            //Remet les labels à 0
            lblQuestion.Text = "Question N°: " + ana.QuestionNumero;
            lblReponse.Text = "Nombre de réponse juste : " + ana.NombreReponseJuste;

            //Tire un nouveau  mot
            ana.ChoixDunMot();
            ana.Question = ana.MelangeMots(ana.Reponse);
            DessineLesBoutons(ana.Question);

        }

        private void btnReponse_Click(object sender, EventArgs e)
        {
            //Affiche la réponse
            for (int j = 0; j < ana.Reponse.Length; j++)
            {
                ListeLettre[j].Text = ana.Reponse[j].ToString();
            }
            btnReponse.Enabled = false;
            btnAnnuler.Enabled = false;
            
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            //Fait passer à la question suivante
            btnReponse.Enabled = true;
            btnAnnuler.Enabled = true;

            //Incrémente le nombre de question
            ana.QuestionNumero++;
            lblQuestion.Text = "Question N°: " + ana.QuestionNumero;

            //Tire un nouveau mot
            ana.ChoixDunMot();
            ana.Question = ana.MelangeMots(ana.Reponse);
            DessineLesBoutons(ana.Question);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            //Vérifie si l'utilisateur peut annuler son dernier click
            if (nbLettreMise != 0)
            {
                nbLettreMise--;
                btnClicke[nbLettreMise].Enabled = true;
                ListeLettre[nbLettreMise].Text = "-";
                btnClicke.RemoveAt(nbLettreMise);
                if (nbLettreMise == 0)
                {
                    btnAnnuler.Enabled = false;
                }

            }
        }
    }
}
