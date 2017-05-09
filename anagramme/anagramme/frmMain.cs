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
                gbxQuestion.Controls.Add(new Button() { Size = new Size(80, 80), Location = new Point(xQuestion, 25), Text = lettre.ToString() });
                xQuestion += 90;
            }

            //  Gbx Reponse :
            gbxReponse.Controls.Clear();
            int xReponse = 10;
            foreach (char lettre in lettres)
            {
                gbxReponse.Controls.Add(new Button() { Size = new Size(80, 80), Location = new Point(xReponse, 25), Text = "-" });
                xReponse += 90;
            }
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

        }
    }
}
