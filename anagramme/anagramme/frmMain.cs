/*
* Auteur       :   Marco Vlajkovic
* Projet       :   Anagramme
* Description  :   L'utilisateur doit reformer le mot dont les lettres on étées melangées.
* Version      :    V1.0
* Date         :   4 mai 2017
*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace anagramme
{
    public partial class frmMain : Form
    {
        //  Déclaration des variables
        Anagramme ana;
        List<Button> ListeBtnReponse = new List<Button>();
        List<Button> ListebtnClique = new List<Button>();
        int nbLettreMise = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //  Met le mot "anagramme" comme premier mot
            ana = new Anagramme("ANAGRAMME");
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;
            DessineLesBoutons(ana.MelangeMot("ANAGRAMME"));
        }

        /// <summary>
        /// Dessine les boutons (les lettres mélanger + réponse utilisateur)
        /// </summary>
        /// <param name="mot"></param>
        public void DessineLesBoutons(string mot)
        {
            //  Vider les listes lors d'un nouveau mot
            ListeBtnReponse.Clear();
            ListebtnClique.Clear();
            nbLettreMise = 0;
            char[] lettres = mot.ToCharArray();
            Size sizeBtn = new Size(80, 80); ;
            Font fontBtn = new Font(FontFamily.GenericSansSerif, 18, FontStyle.Bold);

            //  Vide les groupes box
            gbxQuestion.Controls.Clear();
            gbxReponse.Controls.Clear();

            int poseXBtn = 10;

            //  Générer les boutons par rapport au nombre de lettres dans le mot 
            foreach (char lettre in lettres)
            {
                Button monBtnMelanger = new Button();
                Button monBtnReponse = new Button();

                monBtnMelanger.Size = sizeBtn;
                monBtnMelanger.Location = new Point(poseXBtn, 25);
                monBtnMelanger.Text = lettre.ToString();
                monBtnMelanger.Click += monBtnMelanger_Click;
                monBtnMelanger.ForeColor = Color.Blue;
                monBtnMelanger.Font = fontBtn;
                gbxQuestion.Controls.Add(monBtnMelanger);

                monBtnReponse.Size = sizeBtn;
                monBtnReponse.Location = new Point(poseXBtn, 25);
                monBtnReponse.Text = "-";
                monBtnReponse.Enabled = false;
                monBtnReponse.Font = fontBtn;
                gbxReponse.Controls.Add(monBtnReponse);
                ListeBtnReponse.Add(monBtnReponse);
                poseXBtn += 90;
            }
        }

        /// <summary>
        /// Insere la lettre sur laquel on a cliquer dans la liste du bas (la réponse de l'utilisateur)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void monBtnMelanger_Click(object sender, EventArgs e)
        {
            btnAnnuler.Enabled = true;
            //  Met le texte du bouton cliqué dans le bouton de reponse 
            ListeBtnReponse[nbLettreMise].Text = (sender as Button).Text;
            ListebtnClique.Add(sender as Button);
            (sender as Button).Enabled = false;
            nbLettreMise++;

            //  Vérifie si c'est le bon mot 
            if (ana.Reponse.Length == nbLettreMise)
            {
                string solution = String.Empty;
                foreach (Button reponse in ListeBtnReponse)
                {
                    if (reponse.Text != "-")
                        solution += reponse.Text;
                }
                ana.PropositionUtilisateur = solution.ToUpper();
                if (ana.isReponseOk())
                {
                    ana.NombreReponseJuste++;
                    btnAnnuler.Enabled = false;
                    btnAfficheReponse.Enabled = false;
                    lblReponse.Text = "Nombre de réponse juste : " + ana.NombreReponseJuste;
                    MessageBox.Show("Vous avez trouvé le mot", "Gagné");
                }
                else
                {
                    MessageBox.Show("La réponse que vous avez donné est incorrect !", "Information");
                }
            }
        }

        /// <summary>
        /// Renitialise les scores et demmare une nouvelle partie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {
            btnAnnuler.Enabled = false;
            btnAfficheReponse.Enabled = true;
            btnSuivant.Enabled = true;
            ana.NombreReponseJuste = 0;
            ana.QuestionNumero = 1;

            //  Remet les labels à 0
            lblQuestion.Text = "Question N° : " + ana.QuestionNumero;
            lblReponse.Text = "Nombre de réponse juste : " + ana.NombreReponseJuste;

            //  Tire un nouveau mot
            ana.ChoixDunMot();
            ana.Question = ana.MelangeMot(ana.Reponse);
            DessineLesBoutons(ana.Question);
        }

        /// <summary>
        /// Affiche la réponse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReponse_Click(object sender, EventArgs e)
        {
            //  Affiche la réponse
            for (int j = 0; j < ana.Reponse.Length; j++)
            {
                ListeBtnReponse[j].Text = ana.Reponse[j].ToString();
            }
            //  Desactive les controls pour l'empecher de continuer sur ce mot
            btnAfficheReponse.Enabled = false;
            btnAnnuler.Enabled = false;
        }

        /// <summary>
        /// Passe à la question suivante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            //  Fait passer à la question suivante
            btnAfficheReponse.Enabled = true;
            btnAnnuler.Enabled = true;

            //  Incrémente le nombre de question
            ana.QuestionNumero++;
            lblQuestion.Text = "Question N° : " + ana.QuestionNumero;

            //  Tire un nouveau mot
            ana.ChoixDunMot();
            ana.Question = ana.MelangeMot(ana.Reponse);
            DessineLesBoutons(ana.Question);
        }

        /// <summary>
        /// Annule la derniere lettre inseré
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            //  Vérifie si l'utilisateur peut annuler son dernier click
            if (nbLettreMise != 0)
            {
                nbLettreMise--;
                ListebtnClique[nbLettreMise].Enabled = true;
                ListeBtnReponse[nbLettreMise].Text = "-";
                ListebtnClique.RemoveAt(nbLettreMise);
                if (nbLettreMise == 0)
                {
                    btnAnnuler.Enabled = false;
                }
            }
        }
    }
}