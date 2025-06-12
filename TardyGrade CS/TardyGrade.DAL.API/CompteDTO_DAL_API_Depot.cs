using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    public class CompteDTO_DAL_API_Depot : Depot_DAL_API<CompteDTO_DAL_API>
    {
        string type = null;

        public CompteDTO_DAL_API_Depot(string t)
        {
            this.type = t;
        }


        public override IEnumerable<CompteDTO_DAL_API> GetAll()
        {
            throw new NotImplementedException();
        }

        public override CompteDTO_DAL_API? GetByDates(DateTime dateDebut, DateTime dateFin)
        {
            throw new NotImplementedException();
        }

        public override CompteDTO_DAL_API Insert(CompteDTO_DAL_API entity)
        {
            OuvrirConnexion();
            Commande.CommandText = "INSERT INTO CompteDTO (DateId, Pseudo, NombrePosts, NombreCommentaires, Type) VALUES (@dateId, @pseudo, @nombrePosts, @nombreCommentaires, @type)";
            Commande.Parameters.AddWithValue("@dateId", entity.DateId);
            Commande.Parameters.AddWithValue("@pseudo", entity.Pseudo);
            Commande.Parameters.AddWithValue("@nombrePosts", entity.NombrePosts);
            Commande.Parameters.AddWithValue("@nombreCommentaires", entity.NombreCommentaires);
            Commande.Parameters.AddWithValue("@type", type);
            Commande.ExecuteNonQuery();
            FermerConnexion();

            return entity;
        }

        public override IEnumerable<CompteDTO_DAL_API> GetByIdDate(int dateId)
        {
            List<CompteDTO_DAL_API> compteDTOs = new List<CompteDTO_DAL_API>();

            OuvrirConnexion();
            if (type == "ComptesPostantLePlus")
            {
                Commande.CommandText = "SELECT id, Pseudo, NombrePosts, NombreCommentaires FROM CompteDTO WHERE DateId = @dateId AND Type = @type ORDER BY NombrePosts DESC";
            }
            else if (type == "ComptesCommentantLePlus")
            {
                Commande.CommandText = "SELECT id, Pseudo, NombrePosts, NombreCommentaires FROM CompteDTO WHERE DateId = @dateId AND Type = @type ORDER BY NombreCommentaires DESC";
            }
            else
            {
                Commande.CommandText = "SELECT id, Pseudo, NombrePosts, NombreCommentaires FROM CompteDTO WHERE DateId = @dateId AND Type = @type";
            }
            Commande.Parameters.AddWithValue("@dateId", dateId);
            Commande.Parameters.AddWithValue("@type", type);
            var reader = Commande.ExecuteReader();
            while (reader.Read())
            {
                compteDTOs.Add(new CompteDTO_DAL_API(reader.GetInt32(0), dateId, reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));
            }
            reader.Close();
            reader.Dispose();
            FermerConnexion();

            return compteDTOs;
        }

        public override bool Delete(int Id, DateTime dateDebut, DateTime dateFin)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteByIdDate(int dateId)
        {
            Boolean success = false;

            OuvrirConnexion();

            Commande.CommandText = "DELETE FROM CompteDTO WHERE DateId = @dateId AND Type = @type";
            Commande.Parameters.AddWithValue("@dateId", dateId);
            Commande.Parameters.AddWithValue("@type", type);
            success = Commande.ExecuteNonQuery() > 0;

            FermerConnexion();

            return success;
        }
    }
}
