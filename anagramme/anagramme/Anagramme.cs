/*
 *Ramushi Ardi
 *04.05.2017
 *Version : 1.0
 *Jeu d'anagramme, l'utilisateur doit reformer le mot dont les lettres on étées melangées.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace anagramme
{
    class Anagramme
    {
        //Déclaration des atributs
        List<string> _listMots;
        string _reponse;
        int _nombreReponseJuste;
        string _propositionUtilisateur;
        string _question;
        int _questionNumero;

        //Getter-Setter
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

        //Constructeur
        public Anagramme()
        {


        }

        //Constructeur avec un paramètre
        public Anagramme(string unMot)
        {

        }

        //Charge la liste des mots
        void ChargeListeMots()
        {
            ListMots = new List<string>();
            foreach (string animal in File.ReadAllLines(@"..\..\Resources\animaux.txt"))
            {
                ListMots.Add(animal);
            }
        }


        //Choisi un mot alèatoirement
        void ChoixDunMot()
        {
            Random rdm = new Random();
            Reponse = ListMots[rdm.Next(0, ListMots.Count)];
        }

        //Vérifie si la réponse de l'utilisateur est juste
        bool isReponseOK()
        {
            return Reponse == PropositionUtilisateur;
        }

        //Mélange le mot
        string MelangeMot(string unMot)
        {
            return "";
        }
    }
}
