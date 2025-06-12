using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    public class PostDTO_DAL_API_Depot : Depot_DAL_API<PostDTO_DAL_API>
    {
        string type = null;

        public PostDTO_DAL_API_Depot(string t)
        {
            this.type = t;
        }


        public override IEnumerable<PostDTO_DAL_API> GetAll()
        {
            throw new NotImplementedException();
        }

        public override PostDTO_DAL_API? GetByDates(DateTime dateDebut, DateTime dateFin)
        {
            throw new NotImplementedException();
        }

        public override PostDTO_DAL_API Insert(PostDTO_DAL_API entity)
        {
            OuvrirConnexion();
            Commande.CommandText = "INSERT INTO PostDTO ( DateId, Id_Post, Titre, PseudoAuteur, DatePublication, NombreLikes, NombreSuperLikes, NombreCommentaires, Type) VALUES (@dateId, @id_Post, @titre, @pseudoAuteur, @datePublication, @nombreLikes, @nombreSuperLikes, @nombreCommentaires, @type)";
            Commande.Parameters.AddWithValue("@dateId", entity.DateId);
            Commande.Parameters.AddWithValue("@id_Post", entity.Id_Post);
            Commande.Parameters.AddWithValue("@titre", entity.Titre);
            Commande.Parameters.AddWithValue("@pseudoAuteur", entity.PseudoAuteur);
            Commande.Parameters.AddWithValue("@datePublication", entity.DatePublication);
            Commande.Parameters.AddWithValue("@nombreLikes", entity.NombreLikes);
            Commande.Parameters.AddWithValue("@nombreSuperLikes", entity.NombreSuperLikes);
            Commande.Parameters.AddWithValue("@nombreCommentaires", entity.NombreCommentaires);
            Commande.Parameters.AddWithValue("@type", type);
            Commande.ExecuteNonQuery();
            FermerConnexion();

            return entity;
        }

        public override IEnumerable<PostDTO_DAL_API> GetByIdDate(int dateId) 
        {
            List<PostDTO_DAL_API> postDTOs = new List<PostDTO_DAL_API>();

            OuvrirConnexion();
            if (type == "PostsLesPlusLikes")
            {
                Commande.CommandText = "SELECT id, Id_Post, Titre, PseudoAuteur, DatePublication, NombreLikes, NombreSuperLikes, NombreCommentaires FROM PostDTO WHERE DateId = @dateId AND Type = @type ORDER BY NombreLikes DESC";
            }
            else if (type == "PostsLesPlusSuperLikes")
            {
                Commande.CommandText = "SELECT id, Id_Post, Titre, PseudoAuteur, DatePublication, NombreLikes, NombreSuperLikes, NombreCommentaires FROM PostDTO WHERE DateId = @dateId AND Type = @type ORDER BY NombreSuperLikes DESC";
            }
            else if (type == "PostsLesPlusCommentes")
            {
                Commande.CommandText = "SELECT id, Id_Post, Titre, PseudoAuteur, DatePublication, NombreLikes, NombreSuperLikes, NombreCommentaires FROM PostDTO WHERE DateId = @dateId AND Type = @type ORDER BY NombreCommentaires DESC";
            }
            else
            {
                Commande.CommandText = "SELECT id, Id_Post, Titre, PseudoAuteur, DatePublication, NombreLikes, NombreSuperLikes, NombreCommentaires FROM PostDTO WHERE DateId = @dateId AND Type = @type";
            }

            Commande.Parameters.AddWithValue("@dateId", dateId);
            Commande.Parameters.AddWithValue("@type", type);
            var reader = Commande.ExecuteReader();
            while (reader.Read())
            {
                PostDTO_DAL_API postDTO = new PostDTO_DAL_API(reader.GetInt32(0), dateId, reader.GetInt32(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                postDTOs.Add(postDTO);
            }
            reader.Close();
            reader.Dispose();
            FermerConnexion();

            return postDTOs;
        }

        public override Boolean Delete(int Id, DateTime dateDebut, DateTime dateFin)
        {
            throw new NotImplementedException();
        }

        public override Boolean DeleteByIdDate(int dateId)
        {
            Boolean success = false;

            OuvrirConnexion();

            Commande.CommandText = "DELETE FROM PostDTO WHERE DateId = @dateId AND Type = @type";
            Commande.Parameters.AddWithValue("@dateId", dateId);
            Commande.Parameters.AddWithValue("@type", type);
            success = Commande.ExecuteNonQuery() > 0;

            FermerConnexion();

            return success;
        }
    }
}
