using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardyGrade.BLL;
using TardyGrade.DTO;
using TardyGrade.Services;

namespace TardyGrade.Services.Tests
{
    public class NombreStats_Services_Tests
    {
        // On test la méthode GetByDates
        [Fact]
        public void NombreStats_Service_GetByDates()
        {
            // On mock le depot
            var mock = new Mock<INombreStats_Depot<NombreStats>>();

            #region Liste des ComptesDTO et des PostsDTO
            // date des posts 
            var datePost = new DateTime(2021, 1, 1);

            var ComptesPostantLePlus = new List<CompteDTO>
            {
                new CompteDTO(1, "Pseudo1", 1, 1),
                new CompteDTO(2, "Pseudo2", 2, 2),
                new CompteDTO(3, "Pseudo3", 3, 3)
            };
            var ComptesCommentantLePlus = new List<CompteDTO>
            {
                new CompteDTO(1, "Pseudo1", 1, 1),
                new CompteDTO(2, "Pseudo2", 2, 2),
                new CompteDTO(3, "Pseudo3", 3, 3)
            };

            var PostsLesPlusLikes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            var PostsLesPlusSuperLikes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            var PostsLesPlusCommentes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            #endregion

            // date de début et de fin
            var dateDebut = new DateTime(2020, 1, 1);
            var dateFin = new DateTime(2022, 1, 1);

            // On mock la méthode GetByDates
            mock.Setup(x => x.GetByDates(dateDebut, dateFin))
                .Returns(new NombreStats(1, dateDebut, dateFin, 1, 1, 1, 1, 1, 1, ComptesPostantLePlus, ComptesCommentantLePlus, PostsLesPlusLikes, PostsLesPlusSuperLikes, PostsLesPlusCommentes));

            // Arrange
            NombreStats_Service service = new NombreStats_Service(mock.Object);

            // Act
            var result = service.GetByDates(dateDebut, dateFin);

            // Assert
            Assert.Equal(1, result.Id);
            Assert.Equal(dateDebut, result.DateDebut);
            Assert.Equal(dateFin, result.DateFin);
            Assert.Equal(1, result.NombreCreationsComptes);
            Assert.Equal(1, result.NombreCreationsPosts);
            Assert.Equal(1, result.NombreCreationsCommentaires);
            Assert.Equal(1, result.NombreCreationsLikes);
            Assert.Equal(1, result.MoyenneLikesPosts);
            Assert.Equal(1, result.MoyenneCommentairesPosts);
            // Pour faire simple on compte le nombre de lignes
            Assert.Equal(3, result.ComptesPostantLePlus.Count);
            Assert.Equal(3, result.ComptesCommentantLePlus.Count);
            Assert.Equal(3, result.PostsLesPlusLikes.Count);
            Assert.Equal(3, result.PostsLesPlusSuperLikes.Count);
            Assert.Equal(3, result.PostsLesPlusCommentes.Count);
            mock.Verify(x => x.GetByDates(dateDebut, dateFin), Times.Once);
        }

        // On test la méthode GetAll
        [Fact]
        public void NombreStats_Service_GetAll()
        {
            // On mock le depot
            var mock = new Mock<INombreStats_Depot<NombreStats>>();

            #region Liste des ComptesDTO et des PostsDTO
            // date des posts 
            var datePost = new DateTime(2021, 1, 1);

            var ComptesPostantLePlus = new List<CompteDTO>
            {
                new CompteDTO(1, "Pseudo1", 1, 1),
                new CompteDTO(2, "Pseudo2", 2, 2),
                new CompteDTO(3, "Pseudo3", 3, 3)
            };
            var ComptesCommentantLePlus = new List<CompteDTO>
            {
                new CompteDTO(1, "Pseudo1", 1, 1),
                new CompteDTO(2, "Pseudo2", 2, 2),
                new CompteDTO(3, "Pseudo3", 3, 3)
            };

            var PostsLesPlusLikes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            var PostsLesPlusSuperLikes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            var PostsLesPlusCommentes = new List<PostDTO>
            {
                new PostDTO(1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                new PostDTO(2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                new PostDTO(3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
            };
            #endregion

            // On mock la méthode GetAll
            mock.Setup(x => x.GetAll())
                .Returns(new List<NombreStats>
                {
                    new NombreStats(1, DateTime.Now, DateTime.Now, 1, 1, 1, 1, 1, 1, ComptesPostantLePlus, ComptesCommentantLePlus, PostsLesPlusLikes, PostsLesPlusSuperLikes, PostsLesPlusCommentes),
                    new NombreStats(2, DateTime.Now, DateTime.Now, 2, 2, 2, 2, 2, 2, ComptesPostantLePlus, ComptesCommentantLePlus, PostsLesPlusLikes, PostsLesPlusSuperLikes, PostsLesPlusCommentes),
                    new NombreStats(3, DateTime.Now, DateTime.Now, 3, 3, 3, 3, 3, 3, ComptesPostantLePlus, ComptesCommentantLePlus, PostsLesPlusLikes, PostsLesPlusSuperLikes, PostsLesPlusCommentes)
                });

            // Arange 
            NombreStats_Service service = new NombreStats_Service(mock.Object);

            // Act
            var result = service.GetAll();

            // Assert
            Assert.Equal(3, result.Count());
            mock.Verify(x => x.GetAll(), Times.Once);
        }
    }
}
