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
        Anagramme ana;
        List<Button> ListeLettre = new List<Button>();
        List<Button> btnClicke = new List<Button>();
        int i = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            
            ana = new Anagramme("ANAGRAMME");
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;
            DessineLesBoutons(ana.MelangeMots("ANAGRAMME"));
            
        }

        public void DessineLesBoutons(string mot)
        {
            ListeLettre.Clear();
            btnClicke.Clear();
            i = 0;
            char[] lettres = mot.ToCharArray();

            //  Gbx Question :
            gbxQuestion.Controls.Clear();
            int xQuestion = 10;
            foreach (char lettre in lettres)
            {
                Button monBtn = new Button();

                monBtn.Size = new Size(80, 80);
                monBtn.Location = new Point(xQuestion, 25);
                monBtn.Text = lettre.ToString();
                monBtn.Click += monBtn_Click;
                gbxQuestion.Controls.Add(monBtn);
                // ListeLettre.Add(monBtn);
                xQuestion += 90;
            }

            //  Gbx Reponse :
            gbxReponse.Controls.Clear();
            int xReponse = 10;

            foreach (char lettre in lettres)
            {
                Button maLettre = new Button();
                maLettre.Size = new Size(80, 80);
                maLettre.Location = new Point(xReponse, 25);
                maLettre.Text = "-";
                maLettre.Enabled = false;
                gbxReponse.Controls.Add(maLettre);
                ListeLettre.Add(maLettre);
                xReponse += 90;

            }

        }

        void monBtn_Click(object sender, EventArgs e)
        {
            ListeLettre[i].Text = (sender as Button).Text;
            btnClicke.Add(sender as Button);
            (sender as Button).Enabled = false;
            i++;
            if (ana.Reponse.Length == i)
            {
                string solution = "";
                foreach (Button reponse in ListeLettre)
                {
                    if (reponse.Text != "-")
                        solution += reponse.Text;
                }
                ana.PropositionUtilisateur = solution.ToUpper();
                Console.WriteLine(ana.Reponse + "   " + solution + "   " + ana.isReponseOk());
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
                    MessageBox.Show("plop", "plop");
                }
            }
            Console.WriteLine("i : " + i + "Reponse : " + ana.Reponse + " reponse lenght : " + ana.Reponse.Length);
        }


        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            btnAnnuler.Enabled = true;
            btnReponse.Enabled = true;
            btnSuivant.Enabled = true;
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;
            lblQuestion.Text = "Question N°: " + ana.QuestionNumero;
            lblReponse.Text = "Nombre de réponse juste : " + ana.NombreReponseJuste;

            ana.ChoixDunMot();
            ana.Question = ana.MelangeMots(ana.Reponse);
            DessineLesBoutons(ana.Question);

        }

        private void btnReponse_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < ana.Reponse.Length; j++)
            {
                ListeLettre[j].Text = ana.Reponse[j].ToString();
            }
            btnReponse.Enabled = false;
            btnAnnuler.Enabled = false;
            
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            btnReponse.Enabled = true;
            btnAnnuler.Enabled = true;
            ana.QuestionNumero++;
            lblQuestion.Text = "Question N°: " + ana.QuestionNumero;
            ana.ChoixDunMot();
            ana.Question = ana.MelangeMots(ana.Reponse);
            DessineLesBoutons(ana.Question);
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {

            if (btnClicke.Count > 0)
            {

                i--;
                btnClicke[i].Enabled = true;
                ListeLettre[i].Text = "-";
                btnClicke.RemoveAt(i);

            }
            else
            {
                MessageBox.Show("Vous avez retiré toutes les lettres", "Info");
            }
        }
    }
}
