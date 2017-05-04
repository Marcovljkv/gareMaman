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
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> animaux = new List<string>();

            foreach (string animal in File.ReadAllLines(@"..\..\Resources\animaux.txt"))
            {
                animaux.Add(animal);
                Console.WriteLine(animal);
            }
        }
    }
}
