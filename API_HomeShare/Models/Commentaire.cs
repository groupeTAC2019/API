using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API_HomeShare.Models
{
    public class Commentaire
    {
        #region properties

        private long id;
        private string message;
        private int note;
        private bool valide;



        #endregion

        #region getter setter

        public long Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public string Message
        {
            get
            {
                return message;
            }

            set
            {
                message = value;
            }
        }

        public int Note
        {
            get
            {
                return note;
            }

            set
            {
                note = value;
            }
        }

        public bool Valide
        {
            get
            {
                return valide;
            }

            set
            {
                valide = value;
            }
        }

        #endregion
    }
}