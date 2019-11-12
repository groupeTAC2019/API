using API_HomeShare.Models;
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


        [Route("bien/getall")]
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

        [Route("bien/dernierBien")]
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

        [Route("Bien/{id:int}")]
        public Bien GetById(int id)
        {
            Command cmd = new Command("select * from V_Bien_Bonne_Note");

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
    }
}