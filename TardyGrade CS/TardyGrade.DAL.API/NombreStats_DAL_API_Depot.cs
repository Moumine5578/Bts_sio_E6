using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    public class NombreStats_DAL_API_Depot : Depot_DAL_API<NombreStats_DAL_API>
    {
        
        public override IEnumerable<NombreStats_DAL_API> GetAll()
        {
            List<NombreStats_DAL_API> nombreStats = new List<NombreStats_DAL_API>();

            OuvrirConnexion();

            Commande.CommandText = "SELECT Id, DateDebut, DateFin, NombreCreationsComptes, NombreCreationsPosts, NombreCreationsCommentaires, NombreCreationsLikes, MoyenneLikesPosts, MoyenneCommentairesPosts FROM NombreStats";
            var reader = Commande.ExecuteReader();
            while (reader.Read())
            {
                nombreStats.Add(new NombreStats_DAL_API(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8)));
            }
            reader.Close();
            reader.Dispose();

            FermerConnexion();

            return nombreStats;
        }

        public override NombreStats_DAL_API? GetByDates(DateTime dateDebut, DateTime dateFin)
        {
            NombreStats_DAL_API? nombreStats = null;

            OuvrirConnexion();

            Commande.CommandText = "SELECT Id, DateDebut, DateFin, NombreCreationsComptes, NombreCreationsPosts, NombreCreationsCommentaires, NombreCreationsLikes, MoyenneLikesPosts, MoyenneCommentairesPosts FROM NombreStats WHERE DateDebut = @dateDebut AND DateFin = @dateFin";
            Commande.Parameters.AddWithValue("@dateDebut", dateDebut);
            Commande.Parameters.AddWithValue("@dateFin", dateFin);
            var reader = Commande.ExecuteReader();
            if (reader.Read())
            {
                nombreStats = new NombreStats_DAL_API(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7), reader.GetInt32(8));
            }
            reader.Close();
            reader.Dispose();

            FermerConnexion();

            return nombreStats;
        }

        public override IEnumerable<NombreStats_DAL_API> GetByIdDate(int dateId)
        {
            throw new NotImplementedException();
        }

        public override NombreStats_DAL_API Insert(NombreStats_DAL_API entity)
        {
            OuvrirConnexion();

            Commande.CommandText = "INSERT INTO NombreStats (DateDebut, DateFin, NombreCreationsComptes, NombreCreationsPosts, NombreCreationsCommentaires, NombreCreationsLikes, MoyenneLikesPosts, MoyenneCommentairesPosts) VALUES (@dateDebut, @dateFin, @nombreCreationsComptes, @nombreCreationsPosts, @nombreCreationsCommentaires, @nombreCreationsLikes, @moyenneLikesPosts, @moyenneCommentairesPosts)";
            Commande.Parameters.AddWithValue("@dateDebut", entity.DateDebut);
            Commande.Parameters.AddWithValue("@dateFin", entity.DateFin);
            Commande.Parameters.AddWithValue("@nombreCreationsComptes", entity.NombreCreationsComptes);
            Commande.Parameters.AddWithValue("@nombreCreationsPosts", entity.NombreCreationsPosts);
            Commande.Parameters.AddWithValue("@nombreCreationsCommentaires", entity.NombreCreationsCommentaires);
            Commande.Parameters.AddWithValue("@nombreCreationsLikes", entity.NombreCreationsLikes);
            Commande.Parameters.AddWithValue("@moyenneLikesPosts", entity.MoyenneLikesPosts);
            Commande.Parameters.AddWithValue("@moyenneCommentairesPosts", entity.MoyenneCommentairesPosts);
            entity.Id = Convert.ToInt32(Commande.ExecuteScalar());

            FermerConnexion();

            return entity;
        }

        public override Boolean Delete(int Id, DateTime dateDebut, DateTime dateFin)
        {
            Boolean success = false;

            OuvrirConnexion();

            Commande.CommandText = "DELETE FROM NombreStats WHERE Id = @id AND DateDebut = @dateDebut AND DateFin = @dateFin";
            Commande.Parameters.AddWithValue("@id", Id);
            Commande.Parameters.AddWithValue("@dateDebut", dateDebut);
            Commande.Parameters.AddWithValue("@dateFin", dateFin);
            success = Commande.ExecuteNonQuery() > 0;

            FermerConnexion();

            return success;
        }

        public override Boolean DeleteByIdDate(int dateId)
        {
            throw new NotImplementedException();
        }
    }
}
