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
            DessineLesBoutons(ana.MelangeMot("ANAGRAMME"));
        }

        public void DessineLesBoutons(string mot)
        {

        }

        private void btnNouvellePartie_Click(object sender, EventArgs e)
        {

        }

        private void btnReponse_Click(object sender, EventArgs e)
        {

        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {

        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {

        }
    }
}
