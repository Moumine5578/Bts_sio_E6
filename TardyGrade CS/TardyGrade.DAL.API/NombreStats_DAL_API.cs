namespace TardyGrade.DAL.API
{
    public class NombreStats_DAL_API
    {
        public int? Id { get; set; }
        public DateTime DateDebut { get; private set; }
        public DateTime DateFin { get; private set; }
        public int NombreCreationsComptes { get; private set; }
        public int NombreCreationsPosts { get; private set; }
        public int NombreCreationsCommentaires { get; private set; }
        public int NombreCreationsLikes { get; private set; }
        public int MoyenneLikesPosts { get; private set; }
        public int MoyenneCommentairesPosts { get; private set; }

        #region Constructeurs
        public NombreStats_DAL_API(DateTime dateDebut, DateTime dateFin, int nombreCreationsComptes, int nombreCreationsPosts, int nombreCreationsCommentaires, int nombreCreationsLikes, int moyenneLikesPosts, int moyenneCommentairesPosts)
        {
            this.DateDebut = dateDebut;
            this.DateFin = dateFin;
            this.NombreCreationsComptes = nombreCreationsComptes;
            this.NombreCreationsPosts = nombreCreationsPosts;
            this.NombreCreationsCommentaires = nombreCreationsCommentaires;
            this.NombreCreationsLikes = nombreCreationsLikes;
            this.MoyenneLikesPosts = moyenneLikesPosts;
            this.MoyenneCommentairesPosts = moyenneCommentairesPosts;
        }

        public NombreStats_DAL_API(int? id, DateTime dateDebut, DateTime dateFin, int nombreCreationsComptes, int nombreCreationsPosts, int nombreCreationsCommentaires, int nombreCreationsLikes, int moyenneLikesPosts, int moyenneCommentairesPosts)
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
        }
        #endregion

        #region Operateurs

        // Pour == entre deux objets de type NombreStats, on regarde si l'id, les dates de début et de fin et le nombre de créations de comptes sont les mêmes
        public static bool operator ==(NombreStats_DAL_API ns1, NombreStats_DAL_API ns2)
        {
            if (ns1 is null && ns2 is null)
            {
                return true;
            }
            else if (ns1 is null || ns2 is null)
            {
                return false;
            }
            return ns1.Id == ns2.Id && ns1.DateDebut == ns2.DateDebut && ns1.DateFin == ns2.DateFin && ns1.NombreCreationsComptes == ns2.NombreCreationsComptes;
        }

        public static bool operator !=(NombreStats_DAL_API ns1, NombreStats_DAL_API ns2)
        {
            return !(ns1 == ns2);
        }

        #endregion

    }
}
