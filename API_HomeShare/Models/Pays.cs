using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Pays
    {
        private long _id;
        private string nom;

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

        public string Nom
        {
            get
            {
                return nom;
            }

            set
            {
                nom = value;
            }
        }
    }
}