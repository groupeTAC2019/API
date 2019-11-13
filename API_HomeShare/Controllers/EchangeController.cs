using API_HomeShare.Infrastructures;
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
    public class EchangeController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Echange
        [Route("api/Commentaire")]
        public List<Echange> Get()
        {
            Command cmd = new Command("Select * from Echange");
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Echange> listechange = new List<Echange>();
            foreach (DataRow item in dt.Rows)
            {
                Echange ech = item.toEchange();
                listechange.Add(ech);
            }
                return listechange;
        }

        // GET: api/Echange/5
        [Route("api/Echange/{id:int}")]
        public Echange Get(int id)
        {
            Command cmd = new Command("Select * from Echange where id_echange = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            DataRow item = dt.Rows[0];
            Echange ech = item.toEchange();
            return ech;
        }

        // POST: api/Echange
        [Route("api/Echange")]
        public Echange Post(Echange echang)
        {
            Command cmd = new Command(@"INSERT INTO [dbo].[echange]
            ([date_debut], [date_fin], [valide], [id_bien], [id_membre] )

             output inserted.id_echange

            VALUES ( @date_debut, @date_fin, @valide, @id_bien, @id_membre )  ");

            cmd.AddParameter("date_debut", echang.Date_debut);
            cmd.AddParameter("date_fin", echang.Date_fin);
            cmd.AddParameter("valide", echang.Valide);
            cmd.AddParameter("id_bien", echang.Id_bien);
            cmd.AddParameter("id_membre", echang.Id_membre);

            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            int sid = (int)con.ExecuteScalar(cmd);
            echang.Id_echange = sid;
            return echang;
        }

        // PUT: api/Echange/5
        [Route("api/Echange/{id:int}")]
        [HttpPut]
        public void Put(int id, Echange echang)
        {

            Command cmd = new Command(@"update [dbo].[Echange] set [valide]=@valide where id_echange = @id");
            cmd.AddParameter("id", id);
            cmd.AddParameter("valide", echang.Valide);

            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            con.ExecuteNonQuery(cmd);
        }

        //// DELETE: api/Echange/5
        //public void Delete(int id)
        //{
        //}
    }
}
