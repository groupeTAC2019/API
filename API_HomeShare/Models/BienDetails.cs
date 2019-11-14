using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class BienDetails
    {
        #region properties
        //bien properties
        private int _id;
        private string _titre;
        private string _desc_courte;
        private string _desc_longue;
        private DateTime _date_ajout;
        private int _nb_personne;
        private bool _disponible;
        private DateTime? _date_desactivation;
        private int _id_adresse;
        private int _id_membre;

        //adresse properties
        private string _ville;
        private int _cp;
        private string _rue;
        private int _num;
        private string _boite;
        private int _id_pays;

        //membre properties
        private string _nom;
        private string _prenom;
        private string _email;
        private int _tel;
        private bool _admin;
        private string _mdp;

        //pays properties 
        private string _paysNom;

        //photo properties
        private int? _id_Photo;
        private string _lien;
        private string _legende;

        #endregion

        #region getter setter
        public int Id
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

        public int Id_adresse
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

        public int Id_membre
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

        public string Ville
        {
            get
            {
                return _ville;
            }

            set
            {
                _ville = value;
            }
        }

        public int Cp
        {
            get
            {
                return _cp;
            }

            set
            {
                _cp = value;
            }
        }

        public string Rue
        {
            get
            {
                return _rue;
            }

            set
            {
                _rue = value;
            }
        }

        public int Num
        {
            get
            {
                return _num;
            }

            set
            {
                _num = value;
            }
        }

        public string Boite
        {
            get
            {
                return _boite;
            }

            set
            {
                _boite = value;
            }
        }

        public int Id_pays
        {
            get
            {
                return _id_pays;
            }

            set
            {
                _id_pays = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        public int Tel
        {
            get
            {
                return _tel;
            }

            set
            {
                _tel = value;
            }
        }

        public bool Admin
        {
            get
            {
                return _admin;
            }

            set
            {
                _admin = value;
            }
        }

        public string Mdp
        {
            get
            {
                return _mdp;
            }

            set
            {
                _mdp = value;
            }
        }

        public string PaysNom
        {
            get
            {
                return _paysNom;
            }

            set
            {
                _paysNom = value;
            }
        }

        public int? Id_Photo
        {
            get
            {
                return _id_Photo;
            }

            set
            {
                _id_Photo = value;
            }
        }

        public string Lien
        {
            get
            {
                return _lien;
            }

            set
            {
                _lien = value;
            }
        }

        public string Legende
        {
            get
            {
                return _legende;
            }

            set
            {
                _legende = value;
            }
        }
        #endregion
    }
}