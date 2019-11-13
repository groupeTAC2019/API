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
    public class AdresseController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        //// GET: api/test
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/test/5
        [Route("api/Adresse/{id:int}")]
        public Adresse Get(int id)
        {
            Command cmd = new Command("Select * from Adresse where id_adresse = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("varcon").ProviderName, GetConnectionStrings("varcon").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            DataRow item = dt.Rows[0];
            Adresse adr = new Adresse()
            {
                Id_adresse =(int)item["id_adresse"],
                Ville = (string)item["ville"],
                Cp = (int)item["cp"],
                Rue = (string)item["rue"],
                Num = (int)item["num"],
                Boite = item["boite"] == DBNull.Value ? null : item["boite"].ToString(),
                Id_pays = (int)item["id_pays"]


            };
            return adr ;
        }

        // POST: api/test
        [Route("api/Adresse")]
        public Adresse Post(Adresse adr)
        {
            Command cmd = new Command(@"INSERT INTO [dbo].[Adresse]
           ([ville],[cp],[rue],[num],[boite],[id_pays])
        
            output inserted.id_adresse
        VALUES
               ( @ville, @cp, @rue, @num, @boite, @id_pays)"
         );
            cmd.AddParameter("ville", adr.Ville);
            cmd.AddParameter("cp", adr.Cp);
            cmd.AddParameter("rue", adr.Rue);
            cmd.AddParameter("num", adr.Num);
            cmd.AddParameter("boite", adr.Boite);
            cmd.AddParameter("id_pays", adr.Id_pays);

            Connection conn = new Connection(GetConnectionStrings("varcon").ProviderName, GetConnectionStrings("varcon").ConnectionString);
            int sid = (int)conn.ExecuteScalar(cmd);
            adr.Id_adresse = sid;
            return adr;
        }

        //// PUT: api/test/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/test/5
        //public void Delete(int id)
        //{
        //}

    }
}