using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TardyGrade.DAL.API;
using TradyGrade.DAL.BDD;

namespace TardyGrade.BLL
{
    public class NombreStats_Depot : INombreStats_Depot<NombreStats>
    {

        Client apiClient = new Client();
        Depot_DAL_API<NombreStats_DAL_API> depot;

        // Depots pour les comptesDTO
        Depot_DAL_API<CompteDTO_DAL_API> depotComptesPostantLePlus;
        Depot_DAL_API<CompteDTO_DAL_API> depotComptesCommentantLePlus;

        // Depots pour les postsDTO
        Depot_DAL_API<PostDTO_DAL_API> depotPostsLesPlusLikes;
        Depot_DAL_API<PostDTO_DAL_API> depotPostsLesPlusSuperLikes;
        Depot_DAL_API<PostDTO_DAL_API> depotPostsLesPlusCommentes;

        #region Constructeurs
        public NombreStats_Depot()
        {
            this.depot = new NombreStats_DAL_API_Depot();
            // Depots pour les comptesDTO
            this.depotComptesPostantLePlus = new CompteDTO_DAL_API_Depot("ComptesPostantLePlus");
            this.depotComptesCommentantLePlus = new CompteDTO_DAL_API_Depot("ComptesCommentantLePlus");

            // Depots pour les postsDTO
            this.depotPostsLesPlusLikes = new PostDTO_DAL_API_Depot("PostsLesPlusLikes");
            this.depotPostsLesPlusSuperLikes = new PostDTO_DAL_API_Depot("PostsLesPlusSuperLikes");
            this.depotPostsLesPlusCommentes = new PostDTO_DAL_API_Depot("PostsLesPlusCommentes");
        }

        public NombreStats_Depot(Depot_DAL_API<NombreStats_DAL_API> depot, Depot_DAL_API<CompteDTO_DAL_API> ExDepotCompteDTO, Depot_DAL_API<PostDTO_DAL_API> ExDepotPostDTO)
        {
            this.depot = depot;
            // Depots pour les comptesDTO
            this.depotComptesPostantLePlus = ExDepotCompteDTO;
            this.depotComptesCommentantLePlus = ExDepotCompteDTO;
            // Depots pour les postsDTO
            this.depotPostsLesPlusLikes = ExDepotPostDTO;
            this.depotPostsLesPlusSuperLikes = ExDepotPostDTO;
            this.depotPostsLesPlusCommentes = ExDepotPostDTO;
        }
        #endregion

        public NombreStats GetByDates(DateTime dateDebut, DateTime dateFin)
        {
            NombreStats_DAL_API nombreStats = depot.GetByDates(dateDebut, dateFin);

            if (nombreStats is null)
            {
                // Si les données n'existent pas, récupérer les données depuis l'API et les insérer dans la base de données
                var periode = new Periode_DTO { DateDebut = dateDebut, DateFin = dateFin };

                // Récupération des données depuis l'API
                // NombreStats
                var nombreCreations = apiClient.GetNombreCreationsCompte(periode);
                var nombreCreationsPosts = apiClient.GetNombreCreationsPost(periode);
                var nombreCreationsCommentaires = apiClient.GetNombreCreationsCommentaire(periode);
                var nombreCreationsLikes = apiClient.GetNombreCreationsLike(periode);
                var moyenneLikesPosts = apiClient.GetMoyenneLikesParPosts(periode);
                var moyenneCommentairesPosts = apiClient.GetMoyenneCommentairesParPosts(periode);

                NombreStats_DAL_API newData = new NombreStats_DAL_API(dateDebut, dateFin, nombreCreations, nombreCreationsPosts, nombreCreationsCommentaires, nombreCreationsLikes, moyenneLikesPosts, moyenneCommentairesPosts);
                depot.Insert(newData);

                // On recuperer l'id de la nouvelle insertion pour pouvoir insérer les XxxxxDTO
                nombreStats = depot.GetByDates(dateDebut, dateFin);
                int DateId = nombreStats.Id.Value;

                #region CompteDTO
                // Comptes postant le plus
                var comptesPostantLePlusBdd = apiClient.GetComptesPostantLePlusAsync(periode).Result;
                foreach (var item in comptesPostantLePlusBdd)
                {
                    CompteDTO_DAL_API compteDTO = new CompteDTO_DAL_API(DateId, item.Pseudo, item.NombrePosts, item.NombreCommentaires);
                    depotComptesPostantLePlus.Insert(compteDTO);
                }

                // Comptes commentant le plus
                var comptesCommentantLePlusBdd = apiClient.GetComptesCommentantLePlusAsync(periode).Result;
                foreach (var item in comptesCommentantLePlusBdd)
                {
                    CompteDTO_DAL_API compteDTO = new CompteDTO_DAL_API(DateId, item.Pseudo, item.NombrePosts, item.NombreCommentaires);
                    depotComptesCommentantLePlus.Insert(compteDTO);
                }

                #endregion

                #region PostDTO
                // Les posts les plus likés
                var postsLesPlusLikesBdd = apiClient.GetPostsLikeLePlus(periode);
                foreach (var item in postsLesPlusLikesBdd)
                {
                    PostDTO_DAL_API postDTO = new PostDTO_DAL_API(DateId, item.Id, item.Titre, item.PseudoAuteur, item.DatePublication.DateTime, item.NombreLikes, item.NombreSuperLikes, item.NombreCommentaires);
                    depotPostsLesPlusLikes.Insert(postDTO);
                }

                var postsLesPlusSuperLikesBdd = apiClient.GetPostsSuperLikeLePlus(periode);
                foreach (var item in postsLesPlusSuperLikesBdd)
                {
                    PostDTO_DAL_API postDTO = new PostDTO_DAL_API(DateId, item.Id, item.Titre, item.PseudoAuteur, item.DatePublication.DateTime, item.NombreLikes, item.NombreSuperLikes, item.NombreCommentaires);
                    depotPostsLesPlusSuperLikes.Insert(postDTO);
                }
                #endregion

                //return new NombreStats(newData.Id, newData.DateDebut, newData.DateFin, newData.NombreCreationsComptes, newData.NombreCreationsPosts, newData.NombreCreationsCommentaires, newData.NombreCreationsLikes);
            }



            int dateId = nombreStats.Id.Value;
            #region Récupération des comptesDTOs
            // On fait un select des compteDTOs qui ont posté le plus et commenté le plus avec l'id de la période
            // Créations des listes de comptesDTO
            List<CompteDTO> comptesPostantLePlus = new List<CompteDTO>();
            List<CompteDTO> comptesCommentantLePlus = new List<CompteDTO>();

            // On récupère les comptesDTOs qui ont posté le plus
            List<CompteDTO_DAL_API> comptesPostantLePlusSelect = new List<CompteDTO_DAL_API>(depotComptesPostantLePlus.GetByIdDate(dateId));
            foreach (var item in comptesPostantLePlusSelect)
            {
                comptesPostantLePlus.Add(new CompteDTO(item.Id, item.Pseudo, item.NombrePosts, item.NombreCommentaires));
            }

            // On récupère les comptesDTOs qui ont commenté le plus
            List<CompteDTO_DAL_API> comptesCommentantLePlusSelect = new List<CompteDTO_DAL_API>(depotComptesCommentantLePlus.GetByIdDate(dateId));
            foreach (var item in comptesCommentantLePlusSelect)
            {
                comptesCommentantLePlus.Add(new CompteDTO(item.Id, item.Pseudo, item.NombrePosts, item.NombreCommentaires));
            }
            #endregion

            #region Récupération des postsDTOs

            // On fait un select des postDTOs qui ont le plus de likes, superlikes et commentaires avec l'id de la période
            // Créations des listes de postDTO
            List<PostDTO> postsLesPlusLikes = new List<PostDTO>();
            List<PostDTO> postsLesPlusSuperLikes = new List<PostDTO>();
            List<PostDTO> postsLesPlusCommentes = new List<PostDTO>();

            // On recupere les postsDTOs qui ont le plus de likes
            List<PostDTO_DAL_API> postsLesPlusLikesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusLikes.GetByIdDate(dateId));
            foreach (var item in postsLesPlusLikesSelect)
            {
                postsLesPlusLikes.Add(new PostDTO(item.Id, item.Id_Post, item.Titre, item.PseudoAuteur, item.DatePublication, item.NombreLikes, item.NombreSuperLikes, item.NombreCommentaires));
            }

            // On recupere les postsDTOs qui ont le plus de superlikes
            List<PostDTO_DAL_API> postsLesPlusSuperLikesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusSuperLikes.GetByIdDate(dateId));
            foreach (var item in postsLesPlusSuperLikesSelect)
            {
                postsLesPlusSuperLikes.Add(new PostDTO(item.Id, item.Id_Post, item.Titre, item.PseudoAuteur, item.DatePublication, item.NombreLikes, item.NombreSuperLikes, item.NombreCommentaires));
            }

            // On recupere les postsDTOs qui ont le plus de commentaires
            List<PostDTO_DAL_API> postsLesPlusCommentesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusCommentes.GetByIdDate(dateId));
            foreach (var item in postsLesPlusCommentesSelect)
            {
                postsLesPlusCommentes.Add(new PostDTO(item.Id, item.Id_Post, item.Titre, item.PseudoAuteur, item.DatePublication, item.NombreLikes, item.NombreSuperLikes, item.NombreCommentaires));
            }
            #endregion

            return new NombreStats(nombreStats.Id, nombreStats.DateDebut, nombreStats.DateFin, nombreStats.NombreCreationsComptes, nombreStats.NombreCreationsPosts, nombreStats.NombreCreationsCommentaires, nombreStats.NombreCreationsLikes, nombreStats.MoyenneLikesPosts, nombreStats.MoyenneCommentairesPosts, comptesPostantLePlus, comptesCommentantLePlus, postsLesPlusLikes, postsLesPlusSuperLikes, postsLesPlusCommentes);
        }
        public IEnumerable<NombreStats> GetAll()
        {
            List<NombreStats_DAL_API> nombreStatsDALAPI = depot.GetAll().ToList();
            List<NombreStats> nombreStats = new List<NombreStats>();

            foreach (var item in nombreStatsDALAPI)
            {
                int dateId = item.Id.Value;
                #region Récupération des comptesDTOs
                // On fait un select des compteDTOs qui ont posté le plus et commenté le plus avec l'id de la période
                // Créations des listes de comptesDTO
                List<CompteDTO> comptesPostantLePlus = new List<CompteDTO>();
                List<CompteDTO> comptesCommentantLePlus = new List<CompteDTO>();

                // On récupère les comptesDTOs qui ont posté le plus
                List<CompteDTO_DAL_API> comptesPostantLePlusSelect = new List<CompteDTO_DAL_API>(depotComptesPostantLePlus.GetByIdDate(dateId));
                foreach (var compteDTOTemp in comptesPostantLePlusSelect)
                {
                    comptesPostantLePlus.Add(new CompteDTO(compteDTOTemp.Id, compteDTOTemp.Pseudo, compteDTOTemp.NombrePosts, compteDTOTemp.NombreCommentaires));
                }

                // On récupère les comptesDTOs qui ont commenté le plus
                List<CompteDTO_DAL_API> comptesCommentantLePlusSelect = new List<CompteDTO_DAL_API>(depotComptesCommentantLePlus.GetByIdDate(dateId));
                foreach (var compteDTOTemp in comptesCommentantLePlusSelect)
                {
                    comptesCommentantLePlus.Add(new CompteDTO(compteDTOTemp.Id, compteDTOTemp.Pseudo, compteDTOTemp.NombrePosts, compteDTOTemp.NombreCommentaires));
                }
                #endregion

                #region Récupération des postsDTOs

                // On fait un select des postDTOs qui ont le plus de likes, superlikes et commentaires avec l'id de la période
                // Créations des listes de postDTO
                List<PostDTO> postsLesPlusLikes = new List<PostDTO>();
                List<PostDTO> postsLesPlusSuperLikes = new List<PostDTO>();
                List<PostDTO> postsLesPlusCommentes = new List<PostDTO>();

                // On recupere les postsDTOs qui ont le plus de likes
                List<PostDTO_DAL_API> postsLesPlusLikesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusLikes.GetByIdDate(dateId));
                foreach (var postTemp in postsLesPlusLikesSelect)
                {
                    postsLesPlusLikes.Add(new PostDTO(postTemp.Id, postTemp.Id_Post, postTemp.Titre, postTemp.PseudoAuteur, postTemp.DatePublication, postTemp.NombreLikes, postTemp.NombreSuperLikes, postTemp.NombreCommentaires));
                }

                // On recupere les postsDTOs qui ont le plus de superlikes
                List<PostDTO_DAL_API> postsLesPlusSuperLikesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusSuperLikes.GetByIdDate(dateId));
                foreach (var postTemp in postsLesPlusSuperLikesSelect)
                {
                    postsLesPlusSuperLikes.Add(new PostDTO(postTemp.Id, postTemp.Id_Post, postTemp.Titre, postTemp.PseudoAuteur, postTemp.DatePublication, postTemp.NombreLikes, postTemp.NombreSuperLikes, postTemp.NombreCommentaires));
                }

                // On recupere les postsDTOs qui ont le plus de commentaires
                List<PostDTO_DAL_API> postsLesPlusCommentesSelect = new List<PostDTO_DAL_API>(depotPostsLesPlusCommentes.GetByIdDate(dateId));
                foreach (var postTemp in postsLesPlusCommentesSelect)
                {
                    postsLesPlusCommentes.Add(new PostDTO(postTemp.Id, postTemp.Id_Post, postTemp.Titre, postTemp.PseudoAuteur, postTemp.DatePublication, postTemp.NombreLikes, postTemp.NombreSuperLikes, postTemp.NombreCommentaires));
                }
                #endregion

                nombreStats.Add(new NombreStats(item.Id, item.DateDebut, item.DateFin, item.NombreCreationsComptes, item.NombreCreationsPosts, item.NombreCreationsCommentaires, item.NombreCreationsLikes, item.MoyenneLikesPosts, item.MoyenneCommentairesPosts, comptesPostantLePlus, comptesCommentantLePlus, postsLesPlusSuperLikes, postsLesPlusLikes, postsLesPlusCommentes));
            }

            return nombreStats;
        }
        public Boolean Delete(int Id, DateTime dateDebut, DateTime dateFin)
        {
            // On regarde si la période existe et à le bon Id
            NombreStats_DAL_API nombreStats = depot.GetByDates(dateDebut, dateFin);
            if (nombreStats is null || nombreStats.Id != Id)
            {
                return false;
            }

            // On supprime les comptesDTOs
            depotComptesPostantLePlus.DeleteByIdDate(Id);
            depotComptesCommentantLePlus.DeleteByIdDate(Id);

            // On supprime les postsDTOs
            depotPostsLesPlusLikes.DeleteByIdDate(Id);
            depotPostsLesPlusSuperLikes.DeleteByIdDate(Id);
            depotPostsLesPlusCommentes.DeleteByIdDate(Id);

            // On supprime la période
            return depot.Delete(Id, dateDebut, dateFin);
        }
    }
}
