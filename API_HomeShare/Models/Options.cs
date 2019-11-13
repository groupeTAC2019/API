using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Options
    {
        private int _id_option;
        private string _nom;

        public int Id_option
        {
            get
            {
                return _id_option;
            }

            set
            {
                _id_option = value;
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
    }
}