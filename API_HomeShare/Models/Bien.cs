using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Bien
    {
        #region properties

        private long _id;
        private string _titre;
        private string _desc_courte;
        private string _desc_longue;
        private DateTime _date_ajout;
        private int _nb_personne;
        private bool _disponible;
        private DateTime? _date_desactivation;
        private long _id_adresse;
        private long _id_membre;

        #endregion

        #region getter setter

        public long Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Titre
        {
            get
            {
                return _titre;
            }

            set
            {
                _titre = value;
            }
        }

        public string Desc_courte
        {
            get
            {
                return _desc_courte;
            }

            set
            {
                _desc_courte = value;
            }
        }

        public string Desc_longue
        {
            get
            {
                return _desc_longue;
            }

            set
            {
                _desc_longue = value;
            }
        }

        public DateTime Date_ajout
        {
            get
            {
                return _date_ajout;
            }

            set
            {
                _date_ajout = value;
            }
        }

        public int Nb_personne
        {
            get
            {
                return _nb_personne;
            }

            set
            {
                _nb_personne = value;
            }
        }

        public bool Disponible
        {
            get
            {
                return _disponible;
            }

            set
            {
                _disponible = value;
            }
        }

        public DateTime? Date_desactivation
        {
            get
            {
                return _date_desactivation;
            }

            set
            {
                _date_desactivation = value;
            }
        }

        public long Id_adresse
        {
            get
            {
                return _id_adresse;
            }

            set
            {
                _id_adresse = value;
            }
        }

        public long Id_membre
        {
            get
            {
                return _id_membre;
            }

            set
            {
                _id_membre = value;
            }
        }
        #endregion
    }
}