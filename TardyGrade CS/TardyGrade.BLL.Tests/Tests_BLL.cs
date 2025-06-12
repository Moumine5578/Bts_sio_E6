using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardyGrade.DAL.API;
using TradyGrade.DAL.BDD;

namespace TardyGrade.BLL.Tests
{
    public class Tests_BLL
    {
        // On test la méthode GetByDates de la classe NombreStats_Depot de la BLL dans le cas où la méthode GetByDates de la DAL_API retourne une valeur
        [Fact]
        public void NombresStats_Depot_GetByDates()
        {
            // date de début et de fin
            var dateDebut = new DateTime(2020, 1, 1);
            var dateFin = new DateTime(2022, 1, 1);

            // On mock le depot DAL_API
            var mock = new Mock<Depot_DAL_API<NombreStats_DAL_API>>();

            // On mock la méthode GetByDates
            mock.Setup(x => x.GetByDates(dateDebut, dateFin))
                .Returns(new NombreStats_DAL_API(1, dateDebut, dateFin, 1, 1, 1, 1, 1, 1));

            // On mock les depots CompteDTO_DAL_API_Depot et PostDTO_DAL_API_Depot (1 chacun) on les fait return un liste de valeurs, pour les tests on mets les meme depot de "CompteDTO_DAL_API_Depot" et "PostDTO_DAL_API_Depot" 
            var mockCompte = new Mock<Depot_DAL_API<CompteDTO_DAL_API>>();
            mockCompte.Setup(x => x.GetByIdDate(1))
                .Returns(new List<CompteDTO_DAL_API>
                {
                    new CompteDTO_DAL_API(1, "Pseudo1", 1, 1),
                    new CompteDTO_DAL_API(2, "Pseudo2", 2, 2),
                    new CompteDTO_DAL_API(3, "Pseudo3", 3, 3)
                });

            // date des posts 
            var datePost = new DateTime(2021, 1, 1);

            var mockPost = new Mock<Depot_DAL_API<PostDTO_DAL_API>>();
            mockPost.Setup(x => x.GetByIdDate(1))
                .Returns(new List<PostDTO_DAL_API>
                {
                    new PostDTO_DAL_API(1, 1, 1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                    new PostDTO_DAL_API(2, 1, 2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                    new PostDTO_DAL_API(3, 1, 3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
                });

            // Arrange
            NombreStats_Depot depot = new NombreStats_Depot(mock.Object, mockCompte.Object, mockPost.Object);

            // Act
            var result = depot.GetByDates(dateDebut, dateFin);

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

            Assert.Equal(3, result.ComptesPostantLePlus.Count);
            Assert.Equal(3, result.ComptesCommentantLePlus.Count);

            Assert.Equal(3, result.PostsLesPlusLikes.Count);
            Assert.Equal(3, result.PostsLesPlusSuperLikes.Count);
            Assert.Equal(3, result.PostsLesPlusCommentes.Count);

            mock.Verify(x => x.GetByDates(dateDebut, dateFin), Times.Once);
            mockCompte.Verify(x => x.GetByIdDate(1), Times.Exactly(2));
            mockPost.Verify(x => x.GetByIdDate(1), Times.Exactly(3));
        }

        // On test la méthode GetAll de la classe NombreStats_Depot de la BLL dans le cas où la méthode GetAll de la DAL_API retourne une liste de valeurs
        [Fact]
        public void NombresStats_Depot_GetAll()
        {
            // On mock le depot DAL_API
            var mock = new Mock<Depot_DAL_API<NombreStats_DAL_API>>();

            // On mock la méthode GetAll
            mock.Setup(x => x.GetAll())
                .Returns(new List<NombreStats_DAL_API>
                {
                    new NombreStats_DAL_API(1, new DateTime(2020, 1, 1), new DateTime(2022, 1, 1), 1, 1, 1, 1, 1, 1),
                    new NombreStats_DAL_API(2, new DateTime(2020, 1, 1), new DateTime(2022, 1, 1), 2, 2, 2, 2, 2, 2),
                    new NombreStats_DAL_API(3, new DateTime(2020, 1, 1), new DateTime(2022, 1, 1), 3, 3, 3, 3, 3, 3)
                });

            // On mock les depots CompteDTO_DAL_API_Depot et PostDTO_DAL_API_Depot (1 chacun) on les fait return un liste de valeurs, pour les tests on mets les meme depot de "CompteDTO_DAL_API_Depot" et "PostDTO_DAL_API_Depot" 
            var mockCompte = new Mock<Depot_DAL_API<CompteDTO_DAL_API>>();
            mockCompte.Setup(x => x.GetByIdDate(1))
                .Returns(new List<CompteDTO_DAL_API>
                {
                    new CompteDTO_DAL_API(1, "Pseudo1", 1, 1),
                    new CompteDTO_DAL_API(2, "Pseudo2", 2, 2),
                    new CompteDTO_DAL_API(3, "Pseudo3", 3, 3)
                });
            mockCompte.Setup(x => x.GetByIdDate(2))
                .Returns(new List<CompteDTO_DAL_API>
                {
                    new CompteDTO_DAL_API(1, "Pseudo1", 1, 1),
                    new CompteDTO_DAL_API(2, "Pseudo2", 2, 2)
                });
            mockCompte.Setup(x => x.GetByIdDate(3))
                .Returns(new List<CompteDTO_DAL_API>
                {
                    new CompteDTO_DAL_API(1, "Pseudo1", 1, 1)
                });

            // date des posts 
            var datePost = new DateTime(2021, 1, 1);

            var mockPost = new Mock<Depot_DAL_API<PostDTO_DAL_API>>();
            mockPost.Setup(x => x.GetByIdDate(1))
                .Returns(new List<PostDTO_DAL_API>
                {
                    new PostDTO_DAL_API(1, 1, 1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                    new PostDTO_DAL_API(2, 1, 2, "Contenu2", "Pseudo1", datePost, 2, 2, 2),
                    new PostDTO_DAL_API(3, 1, 3, "Contenu3", "Pseudo1", datePost, 3, 3, 3)
                });
            mockPost.Setup(x => x.GetByIdDate(2))
                .Returns(new List<PostDTO_DAL_API>
                {
                    new PostDTO_DAL_API(1, 1, 1, "Contenu1", "Pseudo1", datePost, 1, 1, 1),
                    new PostDTO_DAL_API(2, 1, 2, "Contenu2", "Pseudo1", datePost, 2, 2, 2)
                });
            mockPost.Setup(x => x.GetByIdDate(3))
                .Returns(new List<PostDTO_DAL_API>
                {
                    new PostDTO_DAL_API(1, 1, 1, "Contenu1", "Pseudo1", datePost, 1, 1, 1)
                });

            // Arrange
            NombreStats_Depot depot = new NombreStats_Depot(mock.Object, mockCompte.Object, mockPost.Object);

            // Act
            var result = depot.GetAll();

            // Assert
            Assert.NotNull(result); // Vérifie que le résultat n'est pas null
            Assert.Equal(3, result.Count());

            // Vérifie les propriétés de chaque élément retourné
            Assert.Equal(1, result.ElementAt(0).Id);
            Assert.Equal(new DateTime(2020, 1, 1), result.ElementAt(0).DateDebut);
            Assert.Equal(new DateTime(2022, 1, 1), result.ElementAt(0).DateFin);
            Assert.Equal(1, result.ElementAt(0).NombreCreationsComptes);
            Assert.Equal(1, result.ElementAt(0).NombreCreationsPosts);
            Assert.Equal(1, result.ElementAt(0).NombreCreationsCommentaires);
            Assert.Equal(1, result.ElementAt(0).NombreCreationsLikes);
            Assert.Equal(1, result.ElementAt(0).MoyenneLikesPosts);
            Assert.Equal(1, result.ElementAt(0).MoyenneCommentairesPosts);

            Assert.Equal(2, result.ElementAt(1).Id);
            Assert.Equal(new DateTime(2020, 1, 1), result.ElementAt(1).DateDebut);
            Assert.Equal(new DateTime(2022, 1, 1), result.ElementAt(1).DateFin);
            Assert.Equal(2, result.ElementAt(1).NombreCreationsComptes);
            Assert.Equal(2, result.ElementAt(1).NombreCreationsPosts);
            Assert.Equal(2, result.ElementAt(1).NombreCreationsCommentaires);
            Assert.Equal(2, result.ElementAt(1).NombreCreationsLikes);
            Assert.Equal(2, result.ElementAt(1).MoyenneLikesPosts);
            Assert.Equal(2, result.ElementAt(1).MoyenneCommentairesPosts);

            Assert.Equal(3, result.ElementAt(2).Id);
            Assert.Equal(new DateTime(2020, 1, 1), result.ElementAt(2).DateDebut);
            Assert.Equal(new DateTime(2022, 1, 1), result.ElementAt(2).DateFin);
            Assert.Equal(3, result.ElementAt(2).NombreCreationsComptes);
            Assert.Equal(3, result.ElementAt(2).NombreCreationsPosts);
            Assert.Equal(3, result.ElementAt(2).NombreCreationsCommentaires);
            Assert.Equal(3, result.ElementAt(2).NombreCreationsLikes);
            Assert.Equal(3, result.ElementAt(2).MoyenneLikesPosts);


            // Vérifie les listes associées
            Assert.Equal(3, result.ElementAt(0).ComptesPostantLePlus.Count);
            Assert.Equal(3, result.ElementAt(0).ComptesCommentantLePlus.Count);
            Assert.Equal(3, result.ElementAt(0).PostsLesPlusLikes.Count);
            Assert.Equal(3, result.ElementAt(0).PostsLesPlusSuperLikes.Count);
            Assert.Equal(3, result.ElementAt(0).PostsLesPlusCommentes.Count);

            Assert.Equal(2, result.ElementAt(1).ComptesPostantLePlus.Count);
            Assert.Equal(2, result.ElementAt(1).ComptesCommentantLePlus.Count);
            Assert.Equal(2, result.ElementAt(1).PostsLesPlusLikes.Count);
            Assert.Equal(2, result.ElementAt(1).PostsLesPlusSuperLikes.Count);
            Assert.Equal(2, result.ElementAt(1).PostsLesPlusCommentes.Count);

            Assert.Equal(1, result.ElementAt(2).ComptesPostantLePlus.Count);
            Assert.Equal(1, result.ElementAt(2).ComptesCommentantLePlus.Count);
            Assert.Equal(1, result.ElementAt(2).PostsLesPlusLikes.Count);
            Assert.Equal(1, result.ElementAt(2).PostsLesPlusSuperLikes.Count);
            Assert.Equal(1, result.ElementAt(2).PostsLesPlusCommentes.Count);
        }
    }
}