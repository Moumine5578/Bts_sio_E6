using TardyGrade.BLL;
using TardyGrade.DTO;

namespace TardyGrade.Services
{
    public class NombreStats_Service : INombreStats_Service<NombreStats_DTO>
    {
        INombreStats_Depot<NombreStats> depot;

        public NombreStats_Service(INombreStats_Depot<NombreStats> depot)
        {
            this.depot = depot;
        }
        public NombreStats_Service()
        {
            this.depot = new NombreStats_Depot();
        }

        public NombreStats_DTO GetByDates(DateTime DateDebut, DateTime DateFin)
        {
            var nombreStats = depot.GetByDates(DateDebut, DateFin);
            #region ComptesDTO

            List<CompteDTO_DTO> comptesPostantLePlus = new List<CompteDTO_DTO>();
            List<CompteDTO_DTO> comptesCommentantLePlus = new List<CompteDTO_DTO>();

            foreach (var item in nombreStats.ComptesPostantLePlus)
            {
                comptesPostantLePlus.Add(new CompteDTO_DTO
                {
                    Id = item.Id,
                    Pseudo = item.Pseudo,
                    NombrePosts = item.NombrePosts,
                    NombreCommentaires = item.NombreCommentaires
                });
            }
            foreach (var item in nombreStats.ComptesCommentantLePlus)
            {
                comptesCommentantLePlus.Add(new CompteDTO_DTO
                {
                    Id = item.Id,
                    Pseudo = item.Pseudo,
                    NombrePosts = item.NombrePosts,
                    NombreCommentaires = item.NombreCommentaires
                });
            }

            #endregion

            #region PostsDTO

            List<PostDTO_DTO> postsLesPlusLikes = new List<PostDTO_DTO>();
            List<PostDTO_DTO> postsLesPlusSuperLikes = new List<PostDTO_DTO>();
            List<PostDTO_DTO> postsLesPlusCommentes = new List<PostDTO_DTO>();

            foreach (var item in nombreStats.PostsLesPlusLikes)
            {
                postsLesPlusLikes.Add(new PostDTO_DTO
                {
                    Id = item.Id,
                    Id_Post = item.Id_Post,
                    Titre = item.Titre,
                    PseudoAuteur = item.PseudoAuteur,
                    DatePublication = item.DatePublication,
                    NombreLikes = item.NombreLikes,
                    NombreSuperLikes = item.NombreSuperLikes,
                    NombreCommentaires = item.NombreCommentaires
                });
            }
            foreach (var item in nombreStats.PostsLesPlusSuperLikes)
            {
                postsLesPlusSuperLikes.Add(new PostDTO_DTO
                {
                    Id = item.Id,
                    Id_Post = item.Id_Post,
                    Titre = item.Titre,
                    PseudoAuteur = item.PseudoAuteur,
                    DatePublication = item.DatePublication,
                    NombreLikes = item.NombreLikes,
                    NombreSuperLikes = item.NombreSuperLikes,
                    NombreCommentaires = item.NombreCommentaires
                });
            }
            foreach (var item in nombreStats.PostsLesPlusCommentes)
            {
                postsLesPlusCommentes.Add(new PostDTO_DTO
                {
                    Id = item.Id,
                    Id_Post = item.Id_Post,
                    Titre = item.Titre,
                    PseudoAuteur = item.PseudoAuteur,
                    DatePublication = item.DatePublication,
                    NombreLikes = item.NombreLikes,
                    NombreSuperLikes = item.NombreSuperLikes,
                    NombreCommentaires = item.NombreCommentaires
                });
            }

            #endregion

            return new NombreStats_DTO
            {
                Id = nombreStats.Id,
                DateDebut = nombreStats.DateDebut,
                DateFin = nombreStats.DateFin,
                NombreCreationsComptes = nombreStats.NombreCreationsComptes,
                NombreCreationsPosts = nombreStats.NombreCreationsPosts,
                NombreCreationsCommentaires = nombreStats.NombreCreationsCommentaires,
                NombreCreationsLikes = nombreStats.NombreCreationsLikes,
                MoyenneLikesPosts = nombreStats.MoyenneLikesPosts,
                MoyenneCommentairesPosts = nombreStats.MoyenneCommentairesPosts,
                ComptesPostantLePlus = comptesPostantLePlus,
                ComptesCommentantLePlus = comptesCommentantLePlus,
                PostsLesPlusLikes = postsLesPlusLikes,
                PostsLesPlusSuperLikes = postsLesPlusSuperLikes,
                PostsLesPlusCommentes = postsLesPlusCommentes
            };
        }

        public IEnumerable<NombreStats_DTO> GetAll()
        {
            var nombreStats = depot.GetAll();
            List<NombreStats_DTO> nombreStatsDTO = new List<NombreStats_DTO>();

            foreach (var item in nombreStats)
            {
                #region ComptesDTO
                List<CompteDTO_DTO> comptesPostantLePlus = new List<CompteDTO_DTO>();
                List<CompteDTO_DTO> comptesCommentantLePlus = new List<CompteDTO_DTO>();

                foreach (var item2 in item.ComptesPostantLePlus)
                {
                    comptesPostantLePlus.Add(new CompteDTO_DTO
                    {
                        Id = item2.Id,
                        Pseudo = item2.Pseudo,
                        NombrePosts = item2.NombrePosts,
                        NombreCommentaires = item2.NombreCommentaires
                    });
                }
                foreach (var item2 in item.ComptesCommentantLePlus)
                {
                    comptesCommentantLePlus.Add(new CompteDTO_DTO
                    {
                        Id = item2.Id,
                        Pseudo = item2.Pseudo,
                        NombrePosts = item2.NombrePosts,
                        NombreCommentaires = item2.NombreCommentaires
                    });
                }
                #endregion

                #region PostsDTO

                List<PostDTO_DTO> postsLesPlusLikes = new List<PostDTO_DTO>();
                List<PostDTO_DTO> postsLesPlusSuperLikes = new List<PostDTO_DTO>();
                List<PostDTO_DTO> postsLesPlusCommentes = new List<PostDTO_DTO>();

                foreach (var item2 in item.PostsLesPlusLikes)
                {
                    postsLesPlusLikes.Add(new PostDTO_DTO
                    {
                        Id = item2.Id,
                        Id_Post = item2.Id_Post,
                        Titre = item2.Titre,
                        PseudoAuteur = item2.PseudoAuteur,
                        DatePublication = item2.DatePublication,
                        NombreLikes = item2.NombreLikes,
                        NombreSuperLikes = item2.NombreSuperLikes,
                        NombreCommentaires = item2.NombreCommentaires
                    });
                }
                foreach (var item2 in item.PostsLesPlusSuperLikes)
                {
                    postsLesPlusSuperLikes.Add(new PostDTO_DTO
                    {
                        Id = item2.Id,
                        Id_Post = item2.Id_Post,
                        Titre = item2.Titre,
                        PseudoAuteur = item2.PseudoAuteur,
                        DatePublication = item2.DatePublication,
                        NombreLikes = item2.NombreLikes,
                        NombreSuperLikes = item2.NombreSuperLikes,
                        NombreCommentaires = item2.NombreCommentaires
                    });
                }
                foreach (var item2 in item.PostsLesPlusCommentes)
                {
                    postsLesPlusCommentes.Add(new PostDTO_DTO
                    {
                        Id = item2.Id,
                        Id_Post = item2.Id_Post,
                        Titre = item2.Titre,
                        PseudoAuteur = item2.PseudoAuteur,
                        DatePublication = item2.DatePublication,
                        NombreLikes = item2.NombreLikes,
                        NombreSuperLikes = item2.NombreSuperLikes,
                        NombreCommentaires = item2.NombreCommentaires
                    });
                }

                #endregion

                nombreStatsDTO.Add(new NombreStats_DTO
                {
                    Id = item.Id,
                    DateDebut = item.DateDebut,
                    DateFin = item.DateFin,
                    NombreCreationsComptes = item.NombreCreationsComptes,
                    NombreCreationsPosts = item.NombreCreationsPosts,
                    NombreCreationsCommentaires = item.NombreCreationsCommentaires,
                    NombreCreationsLikes = item.NombreCreationsLikes,
                    MoyenneLikesPosts = item.MoyenneLikesPosts,
                    MoyenneCommentairesPosts = item.MoyenneCommentairesPosts,
                    ComptesPostantLePlus = comptesPostantLePlus,
                    ComptesCommentantLePlus = comptesCommentantLePlus,
                    PostsLesPlusLikes = postsLesPlusLikes,
                    PostsLesPlusSuperLikes = postsLesPlusSuperLikes,
                    PostsLesPlusCommentes = postsLesPlusCommentes
                });
            }

            return nombreStatsDTO;
        }

        public bool Delete(int Id, DateTime DateDebut, DateTime DateFin)
        {
            return depot.Delete(Id, DateDebut, DateFin);
        }
    }
}
