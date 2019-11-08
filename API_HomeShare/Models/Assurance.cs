using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Assurance
    {
        private int _id_assurance;
        private string _type;
        private decimal _prix;

        public int Id_assurance
        {
            get
            {
                return _id_assurance;
            }

            set
            {
                _id_assurance = value;
            }
        }

        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                _type = value;
            }
        }

        public decimal Prix
        {
            get
            {
                return _prix;
            }

            set
            {
                _prix = value;
            }
        }
    }
}