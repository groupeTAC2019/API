using API_HomeShare.Infrastructures;
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


        #region GetAll
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
        #endregion

        #region GetDernierBien
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
        #endregion


        [Route("api/biendetails/{id:int}")]
        public BienDetails GetById(int id)

        {
            Command cmd = new Command("Details_Bien", true);

            cmd.AddParameter("id_bien", id.ToString());

            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            DataRow result = dt.Rows[0];
            BienDetails bien = new BienDetails()
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
                Date_ajout = (DateTime)result["date_ajout"],
                Num = (int)result["Num"],
                Rue = result["Rue"].ToString(),
                Ville = result["Ville"].ToString(),
                Cp = (int)result["CP"],
                Boite = result["Boite"].ToString(),
                Id_pays = (int)result["id_pays"],
                PaysNom = result["nomPays"].ToString(),
                Nom = result["nomMembre"].ToString(),
                Email = result["email"].ToString(),
                Tel = (int)result["tel"],
                Admin = (bool)result["is_admin"],
                Id_Photo = result["id_image"] == DBNull.Value ? null : (int?)result["id_image"],
                Legende = result["legende"].ToString(),
                Lien = result["lien"].ToString()
            };

            return bien;
        }
        #endregion

        #region GetBienEntreDates
        [Route("api/bien/entredates")]
        public List<Bien> GetBienEntreDates(DateTime debut, DateTime fin)
        {
            Command cmd = new Command("Details_Bien", true);

            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            cmd.AddParameter("debut", debut.ToString());
            cmd.AddParameter("fin", fin.ToString());

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
        #endregion

        #region Post
        [Route("api/bien")]
        public Bien Post(Bien bien)
        {
            Command cmd = new Command(@"INSERT INTO [dbo].[bien]
                ([titre],
                [desc_courte],
                [desc_longue],
                [date_ajout],
                [nb_personne],
                [disponible],
                [id_adresse],
                [id_membre])
                output inserted.id_bien
                VALUES 
                (
                @titre,
                @desc_courte,
                @desc_longue,
                @date_ajout,
                @nb_personne,
                @disponible,
                @id_adresse,
                @id_membre)");
            cmd.AddParameter("titre", bien.Titre);
            cmd.AddParameter("desc_courte", bien.Desc_courte);
            cmd.AddParameter("desc_longue", bien.Desc_longue);
            cmd.AddParameter("date_ajout", DateTime.Now.Date);
            cmd.AddParameter("nb_personne", bien.Nb_personne);
            cmd.AddParameter("disponible", bien.Disponible);
            cmd.AddParameter("id_adresse", bien.Id_adresse);
            cmd.AddParameter("id_membre", bien.Id_membre);
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);
            int bid = (int)con.ExecuteScalar(cmd);
            bien.Id = bid;
            return bien;
        }
        #endregion

        #region GetBienPays
        [Route("api/bien/pays")]
        public List<Bien> GetBienPays()
        {
            Command cmd = new Command("SELECT * FROM V_Bien_Pays");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Bien> bienListe = new List<Bien>();
            foreach (DataRow row in dt.Rows) {
                Bien bien = row.toBien();
                bienListe.Add(bien);

            }
            return bienListe;
        }
        #endregion

        #region GetBienReputation
        [Route("api/bien/reputation")]
        public List<Bien> GetBienReputation()
        {
            Command cmd = new Command("SELECT * FROM V_Bien_Bonne_Note");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);


        //public Bien PostBien(Bien bien)
        //{


        //    Command cmd = new Command("insert into bien (titre,desc_courte,desc_longue,nb_personne,date_ajout,id_adresse,id_membre)" +
        //                              "values (@titre,@desc_courte,@desc_longue,@nb_personne,@date_ajout,@id_adresse,@id_membre)");
        //    cmd.AddParameter("@titre", bien.Titre);
        //    cmd.AddParameter("@desc_courte", bien.Desc_courte);
        //    cmd.AddParameter("@desc_longue", bien.Desc_longue);
        //    cmd.AddParameter("@nb_personne", bien.Nb_personne);
        //    cmd.AddParameter("@date_ajout", DateTime.Now.Date);
        //    cmd.AddParameter("@id_adresse", Id_adresse);

        //    Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);


            DataTable dt = con.GetDataTable(cmd);
            List<Bien> bienListe = new List<Bien>();
            foreach (DataRow row in dt.Rows)
            {
                Bien bien = row.toBien();
                bienListe.Add(bien);

            }
            return bienListe;
        }
        #endregion
        //}
    }
    
}