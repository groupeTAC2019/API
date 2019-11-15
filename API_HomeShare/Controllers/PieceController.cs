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
    public class PieceController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Piece
        [Route("api/Piece")]
        public List<Piece> Get()
        {
            Command cmd = new Command("Select * from Piece");
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Piece> pe = new List<Piece>();
            foreach (DataRow item in dt.Rows)
            {
                Piece p = new Piece()
                {
                    Id_piece = (int)item["id_piece"],
                    Nom = (string)item["nom"]
                };

                pe.Add(p);
            }
                return pe;
        }

        // GET: api/Piece/5
        [Route("api/Piece/{id:int}")]
        public Piece Get(int id)
        {
            Command cmd = new Command("Select * from Piece where id_piece = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnexion").ProviderName, GetConnectionStrings("DBConnexion").ConnectionString);


            DataTable st = con.GetDataTable(cmd);
            DataRow item = st.Rows[0];
            Piece pc = new Piece()
            {
                Id_piece = (int)item["id_piece"],
                Nom = (string)item["nom"]
            };
            return pc ;
        }

        //// POST: api/Piece
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Piece/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Piece/5
        //public void Delete(int id)
        //{
        //}
    }
}
