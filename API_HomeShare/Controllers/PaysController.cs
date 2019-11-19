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
using System.Web.Http.Cors;
using ToolBox;

namespace API_HomeShare.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PaysController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Pays
        [Route("api/Pays")]
        public List<Pays> Get()
        {
            Command cmd = new Command("Select * from Pays");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);
            DataTable dt = con.GetDataTable(cmd);
            List<Pays> listePays = new List<Pays>();
            foreach (DataRow item in dt.Rows)
            {
                Pays p = item.toPays();
                listePays.Add(p);
            }


            return listePays;
        }
        
        // GET: api/Pays/5
        [Route("api/Pays/{id:int}")]
        public Pays Get(int id)
        {
            Command cmd = new Command("Select * from Pays where id_pays = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable st = con.GetDataTable(cmd);
            DataRow item = st.Rows[0];
            Pays p = item.toPays();

            return p;
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
