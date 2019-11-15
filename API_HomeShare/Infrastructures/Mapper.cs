using API_HomeShare.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace API_HomeShare.Infrastructures
{
    public static class Mapper
    {
        #region adresse
        public static Adresse toAdresse(this DataRow row)
        {
            return new Adresse()
            {
                Id_adresse = (int)row["id_adresse"],
                Ville = (string)row["ville"],
                Cp = (int)row["cp"],
                Rue = (string)row["rue"],
                Num = (int)row["num"],
                Boite = row["boite"] == DBNull.Value ? null : row["boite"].ToString(),
                Id_pays = (int)row["id_pays"]
            };
        }
        #endregion

        #region assurance
        public static Assurance toAssurance(this DataRow row)
        {
            return new Assurance()
            {
                Id_assurance = (int)row["id_assurance"],
                Type = (string)row["type"],
                Prix = row["prix"] == DBNull.Value ? null : (decimal?)row["prix"]
            };
        }
            #endregion

        #region bien
            public static Bien toBien(this DataRow row)
        {
            return new Bien()
            {
                Id = (int)row["id_bien"],
                Titre = row["titre"].ToString(),
                Desc_courte = row["desc_courte"].ToString(),
                Desc_longue = row["desc_longue"].ToString(),
                Nb_personne = (int)row["nb_personne"],
                Disponible = (bool)row["disponible"],
                Date_desactivation = row["date_desactivation"] == DBNull.Value ? null : (DateTime?)row["date_desactivation"],
                Date_ajout = (DateTime)row["date_ajout"],
                Id_membre = (int)row["id_membre"],
                Id_adresse = (int)row["is_adresse"]
            };
        }
        #endregion

        #region commentaire
        public static Commentaire toCommentaire(this DataRow row) {
            return new Commentaire()
            {
                Id = (int)row["id_commentaire"],
                Message = (string)row["message"],
                Note = (int)row["note"],
                Valide = (bool)row["valide"],
                Id_membre = (int)row["id_membre"],
                Id_bien = (int)row["id_bien"]
            }; 
        }

        #endregion

        #region echange
        public static Echange toEchange(this DataRow row)
        {
            return new Echange()
            {
                Id_echange = (int)row["id_echange"],
                Date_debut = (DateTime)row["date_debut"],
                Date_fin = (DateTime)row["date_fin"],
                Valide = (bool)row["valide"],
                Id_membre = (int)row["id_membre"],
                Id_bien = (int)row["id_bien"]
            };
        }
        #endregion

        #region membre
        public static Membre toMembre(this DataRow row)
        {
            return new Membre()
            {
                Id_membre = (int)row["id_membre"],
                Nom = row["nom"].ToString(),
                Prenom = row["prenom"].ToString(),
                Email = row["email"].ToString(),
                Tel = (int)row["tel"],
                Admin = (bool)row["is_admin"],
                Mdp = row["mdp"].ToString(),
                Id_pays = (int)row["id_pays"]
            };
        }
        #endregion

        #region options
        public static Options toOptions(this DataRow row)
        {
            return new Options()
            {
                Id_option = (int)row["id_option"],
                Nom = (string)row["nom"]
            };
        }
        #endregion

        #region pays
        public static Pays toPays(this DataRow row)
        {
            return new Pays()
            {
                Id = (int)row["id_pays"],
                Nom = (string)row["nom"]
            };
        }
        #endregion

        #region photo
        public static Photo toPhoto(this DataRow row)
        {
            return new Photo()
            {
                Id_Photo = (int)row["id_photo"],
                Lien = (string)row["lien"],
                Legende = (string)row["legende"],
                Id_bien = (int)row["id_membre"]
            };
        }
        #endregion

        #region piece
        public static Piece toPiece(this DataRow row)
        {
            return new Piece()
            {
                Id_piece = (int)row["id_piece"],
                Nom = (string)row["nom"],
                Nbr_pieces = (int)row["nbr_pieces"]
            };
        }
        #endregion
    }
}