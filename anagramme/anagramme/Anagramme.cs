/*
* Auteur          :   Marco Vlajkovic
* Projet           :   Anagramme
* Description  :   L'utilisateur doit reformer le mot dont les lettres on étées melangées.
* Version        :    V1.0
* Date            :   4 mai 2017
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
        //  Déclaration des atributs
        List<string> _listMots;
        string _reponse;
        int _nombreReponseJuste;
        string _propositionUtilisateur;
        string _question;
        int _questionNumero;

        #region Getter-Setter
        //  Getter-Setter
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
        #endregion

        /// <summary>
        /// Constructeur
        /// </summary>
        public Anagramme()
        {
            ChargeListeMots();
            ChoixDunMot();
            Question = MelangeMots(Reponse);
        }
        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="mot">mot qu'on veut melanger</param>
        public Anagramme(string mot)
        {
            ChargeListeMots();
            Reponse = mot;
            Question = MelangeMots(Reponse);
        }


        /// <summary>
        /// Charge la liste des mots dans ListMots
        /// </summary>
        public void ChargeListeMots()
        {
            ListMots = new List<string>();
            foreach (string animal in File.ReadAllLines(@"..\..\Resources\animaux.txt"))
            {
                ListMots.Add(animal);
            }
        }

        /// <summary>
        /// Choisi un mot alèatoirement parmi ceux de la liste
        /// </summary>
        public void ChoixDunMot()
        {
            Random rdm = new Random();
            Reponse = ListMots[rdm.Next(0, ListMots.Count)];
        }

        /// <summary>
        /// Vérifie si la réponse de l'utilisateur est juste
        /// </summary>
        /// <returns>True -> reponse juste</returns>
        public bool isReponseOk()
        {
            return Reponse == PropositionUtilisateur;
        }

        /// <summary>
        /// Mélange le mot
        /// </summary>
        /// <param name="unMot">Le mot qu'on veut mélanger</param>
        /// <returns>Le mot mélangé</returns>
        public string MelangeMots(string unMot)
        {
            //  Initialisation
            char[] chars = new char[unMot.Length];
            Random rdm = new Random();
            int index = 0;

            //  Traitement
            while (unMot.Length > 0)
            {
                // On choisi une lettre parmi les lettres restantes (int)
                int next = rdm.Next(0, unMot.Length - 1);
                //  On rajoute la lettre a notre tableau
                chars[index] = unMot[next];
                //  On supprime la lettre du mot originale
                unMot = unMot.Substring(0, next) + unMot.Substring(next + 1);

                ++index;
            }
            //  Retourne le tableau converti en string
            return new String(chars);
        }
    }
}