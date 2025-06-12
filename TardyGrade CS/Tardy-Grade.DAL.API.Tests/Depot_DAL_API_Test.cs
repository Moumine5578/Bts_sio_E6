using TardyGrade.DAL.API;

namespace Tardy_Grade.DAL.API.Tests
{
    public class Depot_DAL_API_Test
    {
        [Fact]
        public void Depot_DAL_OuvrirConnexion()
        {
            //Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            var connexion = new System.Data.SqlClient.SqlConnection();
            var commande = new System.Data.SqlClient.SqlCommand();

            //Act
            depot.OuvrirConnexion(connexion, commande);

            //Assert
            Assert.Equal(connexion, commande.Connection);
            Assert.Equal(System.Data.ConnectionState.Open, connexion.State);
            Assert.Equal(System.Data.ConnectionState.Open, depot.ConnectionState);
        }

        [Fact]
        public void Depot_DAL_FermerConnexion()
        {
            //Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            var connexion = new System.Data.SqlClient.SqlConnection();
            var commande = new System.Data.SqlClient.SqlCommand();
            depot.OuvrirConnexion(connexion, commande);

            //Act
            depot.FermerConnexion(connexion, commande);

            //Assert
            Assert.Equal(System.Data.ConnectionState.Closed, connexion.State);
            Assert.Equal(System.Data.ConnectionState.Closed, depot.ConnectionState);
        }


        [Fact]
        public void Depot_DAL_Insert ()
        {
            // Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            NombreStats_DAL_API entity = new NombreStats_DAL_API(DateTime.Now, DateTime.Now, 1, 1, 1, 1, 1, 1);

            // Act
            var result = depot.Insert(entity);

            // Assert
            Assert.NotNull(result.Id);
        }

        [Fact]
        public void Depot_DAL_GetByDates()
        {
            //Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            DateTime DateDebutTest = new DateTime(2023, 1, 1);
            DateTime DateFinTest = new DateTime(2024, 2, 2);
            NombreStats_DAL_API entity = new NombreStats_DAL_API(DateDebutTest, DateFinTest, 2, 2, 3, 2, 2, 3);
            NombreStats_DAL_API nbStatsInsert = depot.Insert(entity);

            //Act 
            NombreStats_DAL_API nbStatsSelect = depot.GetByDates(DateDebutTest, DateFinTest);

            //Assert
            // On verifie que les deux objet on la meme date de debut et de fin et le meme nombre de creation de compte
            Assert.Equal(nbStatsInsert.DateDebut, nbStatsSelect.DateDebut);
            Assert.Equal(nbStatsInsert.DateFin, nbStatsSelect.DateFin);
            Assert.Equal(nbStatsInsert.NombreCreationsComptes, nbStatsSelect.NombreCreationsComptes);
            Assert.Equal(nbStatsInsert.NombreCreationsPosts, nbStatsSelect.NombreCreationsPosts);
            Assert.Equal(nbStatsInsert.NombreCreationsCommentaires, nbStatsSelect.NombreCreationsCommentaires);
            Assert.Equal(nbStatsInsert.NombreCreationsLikes, nbStatsSelect.NombreCreationsLikes);
            Assert.Equal(nbStatsInsert.MoyenneLikesPosts, nbStatsSelect.MoyenneLikesPosts);
            Assert.Equal(nbStatsInsert.MoyenneCommentairesPosts, nbStatsSelect.MoyenneCommentairesPosts);
        }

        [Fact]
        public void Depot_DAL_GetAll()
        {
            //Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            NombreStats_DAL_API entity = new NombreStats_DAL_API(new DateTime(2023, 1, 1), new DateTime(2024, 2, 2), 2, 2, 2, 2, 2, 2);
            NombreStats_DAL_API entity1 = new NombreStats_DAL_API(new DateTime(2023, 1, 1), new DateTime(2022, 2, 2), 1, 1, 1, 1, 1, 1);
            NombreStats_DAL_API entity2 = new NombreStats_DAL_API(new DateTime(2023, 1, 1), new DateTime(2023, 2, 2), 6, 6, 6, 6, 6, 6);
            depot.Insert(entity);
            depot.Insert(entity1);
            depot.Insert(entity2);

            //Act
            IEnumerable<NombreStats_DAL_API> result = depot.GetAll();

            //Assert
            Assert.NotNull(result);
            //on verifie que la liste contient bien les 3 stats avec les bonnes valeurs
            Assert.Contains(result, x =>
                x.DateDebut == entity.DateDebut &&
                x.DateFin == entity.DateFin &&
                x.NombreCreationsComptes == entity.NombreCreationsComptes &&
                x.NombreCreationsPosts == entity.NombreCreationsPosts &&
                x.NombreCreationsCommentaires == entity.NombreCreationsCommentaires &&
                x.NombreCreationsLikes == entity.NombreCreationsLikes &&
                x.MoyenneLikesPosts == entity.MoyenneLikesPosts &&
                x.MoyenneCommentairesPosts == entity.MoyenneCommentairesPosts);

            Assert.Contains(result, x =>
                x.DateDebut == entity1.DateDebut &&
                x.DateFin == entity1.DateFin &&
                x.NombreCreationsComptes == entity1.NombreCreationsComptes &&
                x.NombreCreationsPosts == entity1.NombreCreationsPosts &&
                x.NombreCreationsCommentaires == entity1.NombreCreationsCommentaires &&
                x.NombreCreationsLikes == entity1.NombreCreationsLikes &&
                x.MoyenneLikesPosts == entity1.MoyenneLikesPosts &&
                x.MoyenneCommentairesPosts == entity1.MoyenneCommentairesPosts);

            Assert.Contains(result, x =>
                x.DateDebut == entity2.DateDebut &&
                x.DateFin == entity2.DateFin &&
                x.NombreCreationsComptes == entity2.NombreCreationsComptes &&
                x.NombreCreationsPosts == entity2.NombreCreationsPosts &&
                x.NombreCreationsCommentaires == entity2.NombreCreationsCommentaires &&
                x.NombreCreationsLikes == entity2.NombreCreationsLikes &&
                x.MoyenneLikesPosts == entity2.MoyenneLikesPosts &&
                x.MoyenneCommentairesPosts == entity2.MoyenneCommentairesPosts);

        }

        [Fact]
        public void Depot_Dal_Delete()
        {
            //Arrange
            Depot_DAL_API<NombreStats_DAL_API> depot = new NombreStats_DAL_API_Depot();
            NombreStats_DAL_API entity = new NombreStats_DAL_API(new DateTime(2003, 1, 1), new DateTime(2025, 2, 2), 2, 2, 2, 2, 2, 2);
            depot.Insert(entity);

            NombreStats_DAL_API entityCreate = depot.GetByDates(entity.DateDebut, entity.DateFin);
            //Act
            if (entityCreate != null && entityCreate.Id != null)
            {
                depot.Delete(entityCreate.Id.Value, entity.DateDebut, entity.DateFin);
            }

            //Assert
            NombreStats_DAL_API entityDelete = depot.GetByDates(entity.DateDebut, entity.DateFin);
            Assert.Null(entityDelete);
        }
    }
}