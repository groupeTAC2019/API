using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_HomeShare.Infrastructures
{
    public static class Mapper
    {
        public static Bien toBien(this DataRow row)
        {
            return new Bien()
            {
                Id = (int)row["id_bien"],
                Titre = row["titre"].ToString(),
                Desc_courte = row["desc_courte"].ToString(),
                Desc_longue = row["desc_longue"].ToString(),
                Nb_personne = (int)row["nb_personne"],
                Disponible = (bool)row["disponible"],
                Date_desactivation = row["date_desactivation"] == DBNull.Value? null: (DateTime?)row["date_desactivation"],
                Date_ajout = (DateTime)row["date_ajout"]
            };
        }
    }
}