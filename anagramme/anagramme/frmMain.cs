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
            ana = new Anagramme();
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;
            DessineLesBoutons(ana.MelangeMots("ANAGRAMME"));
        }

        public void DessineLesBoutons(string mot)
        {
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
        }


        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
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
            MessageBox.Show("La reponse était : " + ana.Reponse + " .", "Abandon", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
            this.btnSuivant_Click(sender, e);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
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
