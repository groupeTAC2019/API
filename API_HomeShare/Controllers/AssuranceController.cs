using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using ToolBox;

namespace API_HomeShare.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AssuranceController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Assurance
        [Route("api/Assurance")]
        public List<Assurance> Get()
        {
            Command cmd = new Command("select * from Assurance");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Assurance> assur = new List<Assurance>();
            foreach (DataRow item in dt.Rows)
            {
                Assurance ass = new Assurance()
                {
                    Id_assurance = (int)item["id_assurance"],
                    Type = (string)item["type"],
                    Prix = item["prix"] == DBNull.Value ? null : (decimal?)item["prix"]
                };
                assur.Add(ass);
            }
            return assur ;
        }
        
        // GET: api/Assurance/5
        [Route("api/Assurance/{id:int}")]
        public Assurance Get(int id)
        {
            Command cmd = new Command("select * from Assurance where id_assurance = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            DataRow item = dt.Rows[0];
            Assurance asr = new Assurance()
            {
                Id_assurance = (int)item["id_assurance"],
                Type = (string)item["type"],
                Prix = item["prix"] == DBNull.Value ? null : (decimal?)item["prix"]
            };

            return asr ;
        }

        //// POST: api/Assurance
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Assurance/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Assurance/5
        //public void Delete(int id)
        //{
        //}
    }
}
