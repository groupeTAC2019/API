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
    public class OptionsController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Options
        [Route("api/Options")]
        public List<Options> Get()
        {
            Command cmd = new Command("Select * from Options");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);


            DataTable dt = con.GetDataTable(cmd);
            List<Options> leRetourVersLeFutur = new List<Options>();
            foreach (DataRow item in dt.Rows)
            {
                Options op = new Options()
                {
                    Id_option = (int)item["id_option"],
                    Nom = (string)item["nom"]
                };
                leRetourVersLeFutur.Add(op);
            }


                return leRetourVersLeFutur;
        }

        // GET: api/Options/5
        [Route("api/Options/{id:int}")]
        public Options Get(int id)
        {
            Command cmd = new Command("Select * from Options where id_option = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable st = con.GetDataTable(cmd);
            DataRow item = st.Rows[0];
            Options opt = new Options()
            {
                Id_option = (int)item["id_option"],
                Nom = (string)item["nom"]
            };

            return opt ;
        }

        //// POST: api/Options
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Options/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Options/5
        //public void Delete(int id)
        //{
        //}
    }
}
