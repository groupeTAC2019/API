using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Controllers
{
    public class Membre
    {
        private long _id_membre;
        private string _nom;
        private string _prenom;
        private string _email;
        private int _tel;
        private bool _admin;
        private string _mdp;
        private long _id_pays;

      

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

        public long Id_pays
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
    }
}