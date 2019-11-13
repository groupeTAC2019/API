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
    public class CommentaireController : ApiController
    {
        public static ConnectionStringSettings GetConnectionStrings(String name)
        {
            ConnectionStringSettings connections = ConfigurationManager.ConnectionStrings[name];
            return connections;
        }
        // GET: api/Commentaire
        [Route("api/Commentaire")]
        public List<Commentaire> Get()
        {
            Command cmd = new Command("Select * from Commentaire");
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);

            DataTable dt = con.GetDataTable(cmd);
            List<Commentaire> comt = new List<Commentaire>();
            foreach (DataRow item in dt.Rows)
            {
                Commentaire co = new Commentaire()
                {
                    Id = (int)item["id_commentaire"],
                    Message = (string)item["message"],
                    Note = (int)item["note"],
                    Valide = (bool)item["valide"],
                    Id_membre = (int)item["id_membre"],
                    Id_bien = (int)item["id_bien"]
                };

                comt.Add(co);
            }
            return comt;
        }

        // GET: api/Commentaire/5
        [Route("api/Commentaire/{id:int}")]
        public Commentaire Get(int id)
        {
            Command cmd = new Command("Select * from Commentaire where id_commentaire = @id");
            cmd.AddParameter("id", id);
            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);


            DataTable dt = con.GetDataTable(cmd);
            DataRow item = dt.Rows[0];
            Commentaire comt = new Commentaire()
            {
                Id = (int)item["id_commentaire"],
                Message = (string)item["message"],
                Note = (int)item["note"],
                Valide = (bool)item["valide"],
                Id_membre = (int)item["id_membre"],
                Id_bien = (int)item["id_bien"]
            };
                return comt;
        }

        // POST: api/Commentaire
        [Route("api/commentaire")]
        public Commentaire Post(Commentaire comentair)
        {
            Command cmd = new Command(@"INSERT INTO [dbo].[commentaire]
            ([message], [note], [valide], [id_membre], [id_bien] )

             output inserted.id_commentaire

            VALUES ( @message, @note, @valide, @id_membre, @id_bien )  ");

            cmd.AddParameter("message", comentair.Message);
            cmd.AddParameter("note", comentair.Note);
            cmd.AddParameter("valide", comentair.Valide);
            cmd.AddParameter("id_membre", comentair.Id_membre);
            cmd.AddParameter("id_bien", comentair.Id_bien);

            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            int sid = (int)con.ExecuteScalar(cmd);
            comentair.Id = sid;
            return comentair;
        }

        // PUT: api/Commentaire/5
        [Route("api/commentaire/{id:int}")]
        [HttpPut]
        public void Put( int id, Commentaire comt)
        {
            Command cmd = new Command(@"update [dbo].[commentaire] set [message]=@message, [note]=@note where id_commentaire = @id");
            cmd.AddParameter("id", id);
            cmd.AddParameter("message", comt.Message);
            cmd.AddParameter("note", comt.Note);

            Connection con = new Connection(GetConnectionStrings("DBConnection").ProviderName, GetConnectionStrings("DBConnection").ConnectionString);
            /*int sid = (int)*/con.ExecuteNonQuery(cmd);
        }

        //// DELETE: api/Commentaire/5
        //public void Delete(int id)
        //{
        //}
    }
}
