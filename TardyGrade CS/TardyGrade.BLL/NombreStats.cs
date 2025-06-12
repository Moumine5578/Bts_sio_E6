namespace TardyGrade.BLL
{
    public class NombreStats
    {
        public int? Id { get; private set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public int NombreCreationsComptes { get; private set; }
        public int NombreCreationsPosts { get; private set; }
        public int NombreCreationsCommentaires { get; private set; }
        public int NombreCreationsLikes { get; private set; }
        public int MoyenneLikesPosts { get; private set; }
        public int MoyenneCommentairesPosts { get; private set; }
        public List<CompteDTO> ComptesPostantLePlus { get; private set; }
        public List<CompteDTO> ComptesCommentantLePlus { get; private set; }
        public List<PostDTO> PostsLesPlusLikes { get; private set; }
        public List<PostDTO> PostsLesPlusSuperLikes { get; private set; }
        public List<PostDTO> PostsLesPlusCommentes { get; private set; }

        #region Constructeurs
        public NombreStats(DateTime dateDebut, DateTime dateFin, int nombreCreationsComptes, int nombreCreationsPosts, int nombreCreationsCommentaires, int nombreCreationsLikes, int moyenneLikesPosts, int moyenneCommentairesPosts, List<CompteDTO> comptesPostantLePlus, List<CompteDTO> comptesCommentantLePlus, List<PostDTO> postsLesPlusLikes, List<PostDTO> postsLesPlusSuperLikes, List<PostDTO> postsLesPlusCommentes)
        {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.NombreCreationsComptes = nombreCreationsComptes;
            this.NombreCreationsPosts = nombreCreationsPosts;
            this.NombreCreationsCommentaires = nombreCreationsCommentaires;
            this.NombreCreationsLikes = nombreCreationsLikes;
            this.MoyenneLikesPosts = moyenneLikesPosts;
            this.MoyenneCommentairesPosts = moyenneCommentairesPosts;
            this.ComptesPostantLePlus = comptesPostantLePlus;
            this.ComptesCommentantLePlus = comptesCommentantLePlus;
            this.PostsLesPlusLikes = postsLesPlusLikes;
            this.PostsLesPlusSuperLikes = postsLesPlusSuperLikes;
            this.PostsLesPlusCommentes = postsLesPlusCommentes;
        }

        public NombreStats(int? id, DateTime dateDebut, DateTime dateFin, int nombreCreationsComptes, int nombreCreationsPosts, int nombreCreationsCommentaires, int nombreCreationsLikes, int moyenneLikesPosts, int moyenneCommentairesPosts, List<CompteDTO> comptesPostantLePlus, List<CompteDTO> comptesCommentantLePlus, List<PostDTO> postsLesPlusLikes, List<PostDTO> postsLesPlusSuperLikes, List<PostDTO> postsLesPlusCommentes)
        {
            this.Id = id;
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.NombreCreationsComptes = nombreCreationsComptes;
            this.NombreCreationsPosts = nombreCreationsPosts;
            this.NombreCreationsCommentaires = nombreCreationsCommentaires;
            this.NombreCreationsLikes = nombreCreationsLikes;
            this.MoyenneLikesPosts = moyenneLikesPosts;
            this.MoyenneCommentairesPosts = moyenneCommentairesPosts;
            this.ComptesPostantLePlus = comptesPostantLePlus;
            this.ComptesCommentantLePlus = comptesCommentantLePlus;
            this.PostsLesPlusLikes = postsLesPlusLikes;
            this.PostsLesPlusSuperLikes = postsLesPlusSuperLikes;
            this.PostsLesPlusCommentes = postsLesPlusCommentes;
        }

        

        #endregion

    }
}

