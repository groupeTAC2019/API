﻿using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Http;
using ToolBox;

namespace API_HomeShare.Controllers
{
    public class BienController : ApiController
    {
        public ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }


        [Route("api/bien/getall")]
        public List<Bien> GetAll()
        {
            Command cmd = new Command("select * from Bien");
            
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Bien> result = new List<Bien>();

            foreach (DataRow row in dt.Rows)
            {
                Bien bien = new Bien()
                {
                    Id = (int)row["id_bien"],
                    Titre = row["titre"].ToString(),
                    Desc_courte = row["desc_courte"].ToString(),
                    Desc_longue = row["desc_longue"].ToString(),
                    Nb_personne = (int)row["nb_personne"],
                    Disponible = (bool)row["disponible"],
                    Date_desactivation = row["date_desactivation"] == DBNull.Value ? null : (DateTime?)row["date_desactivation"],
                    Id_adresse = (int)row["id_adresse"],
                    Id_membre = (int)row["id_membre"],
                    Date_ajout = (DateTime)row["date_ajout"]
                };
                
                result.Add(bien);
            }

            return result;
        }

        [Route("api/bien/dernierBien")]
        public List<Bien> GetDernierBien()
        {
            Command cmd = new Command("select * from V_Dernier_5_Bien");

            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Bien> result = new List<Bien>();

            foreach (DataRow row in dt.Rows)
            {
                Bien bien = new Bien()
                {
                    Id = (int)row["id_bien"],
                    Titre = row["titre bien"].ToString(),
                    Desc_courte = row["description courte"].ToString(),
                    Desc_longue = row["description longue"].ToString(),
                    Nb_personne = (int)row["nombre de personne"],
                    Disponible = (bool)row["Disponible"]

                };

                result.Add(bien);
            }

            return result;
        }

        [Route("api/bien/{id:int}")]
        public Bien GetById(int id)
        {
            Command cmd = new Command("exec Bien_Membre");

            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            DataRow result = dt.Rows[0];
            Bien bien = new Bien()
            {
                Id = (int)result["id_bien"],
                Titre = result["titre"].ToString(),
                Desc_courte = result["desc_courte"].ToString(),
                Desc_longue = result["desc_longue"].ToString(),
                Nb_personne = (int)result["nb_personne"],
                Disponible = (bool)result["disponible"],
                Date_desactivation = result["date_desactivation"] == DBNull.Value ? null : (DateTime?)result["date_desactivation"],
                Id_adresse = (int)result["id_adresse"],
                Id_membre = (int)result["id_membre"],
                Date_ajout = (DateTime)result["date_ajout"]
            };

            return bien;
        }
    }
}