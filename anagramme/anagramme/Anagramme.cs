using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace anagramme
{
    class Anagramme
    {
        List<string> _listMots;
        string _reponse;
        int _nombreReponseJuste;
        string _propositionUtilisateur;
        string _question;
        int _questionNumero;

        public List<string> ListMots
        {
            get { return _listMots; }
            set { _listMots = value; }
        }

        public int NombreReponseJuste
        {
            get { return _nombreReponseJuste; }
            set { _nombreReponseJuste = value; }
        }

        public string PropositionUtilisateur
        {
            get { return _propositionUtilisateur; }
            set { _propositionUtilisateur = value; }
        }

        public string Question
        {
            get { return _question; }
            set { _question = value; }
        }

        public int QuestionNumero
        {
            get { return _questionNumero; }
            set { _questionNumero = value; }
        }

        public string Reponse
        {
            get { return _reponse; }
            set { _reponse = value; }
        }

        public Anagramme()
        {


        }

        public Anagramme(string unMot)
        {

        }

        void ChargeListeMots(){
            ListMots = new List<string>();
            foreach (string animal in File.ReadAllLines(@"..\..\Resources\animaux.txt"))
            {
                ListMots.Add(animal);
            }
        }

        void ChoixDunMot()
        {

        }

        bool isReponseOK()
        {
            return true;
        }

        string MelangeMot(string unMot)
        {
            return "";
        }
    }
}
