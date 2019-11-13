using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Adresse
    {
        private long _id_adresse;
        private string _ville;
        private int _cp;
        private string _rue;
        private int _num;
        private string _boite;
        private long _id_pays;

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