using API_HomeShare.Infrastructures;
using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ToolBox;

namespace API_HomeShare.Controllers
{

    public class MembreController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        [Route("api/Membre")]
        public List<Membre> Get()
        {
            Command cmd = new Command("Select * from Membre WHERE is_delete != 1");
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Membre> listeMembre = new List<Membre>();
            foreach (DataRow item in dt.Rows)
            {
                Membre m = new Membre()
                {
                    Id_membre = (int)item["id_membre"],
                    Nom = item["nom"].ToString(),
                    Prenom = item["prenom"].ToString(),
                    Email = item["email"].ToString(),
                    Tel = (int)item["tel"],
                    Admin = (bool)item["is_admin"],
                    Mdp = item["mdp"].ToString(),
                    Id_pays = (int)item["id_pays"]
                };
                listeMembre.Add(m);
            }
            return listeMembre;
        }

        [Route("api/Membre/{id_Membre:int}")]
        public Membre Get(int id_Membre)
        {
            Command cmd = new Command("Select * from Membre WHERE id_Membre = @id_Membre");
            cmd.AddParameter("id_Membre", id_Membre);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable mt = con.GetDataTable(cmd);
            DataRow item = mt.Rows[0];
            Membre m = new Membre()
            {
                Id_membre = (int)item["id_membre"],
                Nom = item["nom"].ToString(),
                Prenom = item["prenom"].ToString(),
                Email = item["email"].ToString(),
                Tel = (int)item["tel"],
                Admin = (bool)item["is_admin"],
                Mdp = item["mdp"].ToString(),
                Id_pays = (int)item["id_pays"],
            };
            return m;
        }
        [Route("Api/Membre/{id_Membre:int}/Bien")]
        public List<Bien> GetBien(int id_Membre){
            Command cmd = new Command("Bien_Membre",true);
            cmd.AddParameter("id_membre", id_Membre);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Bien> listeBien = new List<Bien>();
            foreach (DataRow item in dt.Rows)
            {
                Bien b = item.toBien();
                listeBien.Add(b);
            }
            return listeBien;
        }

        [Route("api/Membre")]
        public Membre Post(Membre m)
        {
            Command cmd = new Command(@"INSERT INTO [dbo].[membre]
            ([nom]
            ,[prenom]
            ,[email]
            ,[tel]
            ,[is_admin]
            ,[mdp]
            ,[id_pays])
            output inserted.id_membre
            VALUES
            (
            @nom
            ,@prenom
            ,@email
            ,@tel
            ,@is_admin
            ,@mdp
            ,@id_pays)");
            cmd.AddParameter("nom", m.Nom);
            cmd.AddParameter("prenom", m.Prenom);
            cmd.AddParameter("email", m.Email);
            cmd.AddParameter("tel", m.Tel);
            cmd.AddParameter("is_admin", m.Admin);
            cmd.AddParameter("mdp", m.Mdp);
            cmd.AddParameter("id_pays", m.Id_pays);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            int mid = (int)con.ExecuteScalar(cmd);
            m.Id_membre = mid;
            return m;
        }
        /*TEST POST
        {
        "nom":"legrain",
        "prenom":"samuel",
        "email":"l.s@gmail.com",
        "tel":65489531,
        "is_admin":0,
        "mdp":"ls123",
        "id_pays":2
        }*/

        [Route("api/Membre/{id_Membre:int}")]
        public void Put(int id_Membre, Membre m)
        {
            Command cmd = new Command(@"UPDATE [dbo].[membre] 
            SET 
             [nom]= @nom
            ,[prenom]= @prenom
            ,[email]= @email
            ,[tel]= @tel
            ,[is_admin]= @is_admin
            ,[mdp]= @mdp
            ,[id_pays]= @id_pays
            WHERE id_membre = @id_Membre ;");
            cmd.AddParameter("id_Membre", id_Membre);
            cmd.AddParameter("nom", m.Nom);
            cmd.AddParameter("prenom", m.Prenom);
            cmd.AddParameter("email", m.Email);
            cmd.AddParameter("tel", m.Tel);
            cmd.AddParameter("is_admin", m.Admin);
            cmd.AddParameter("mdp", m.Mdp);
            cmd.AddParameter("id_pays", m.Id_pays);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            con.ExecuteScalar(cmd);
        }

        [Route("api/Membre/{id_Membre:int}")]
        public bool Delete(int id_Membre)
        {
            Command cmd = new Command(@"DELETE from Membre WHERE id_Membre = @id_Membre
                                        SELECT is_delete FROM Membre WHERE id_membre = @id_Membre");
            cmd.AddParameter("id_Membre", id_Membre);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            return (bool)con.ExecuteScalar(cmd);
        }
    }
}