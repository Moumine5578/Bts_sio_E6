namespace TardyGrade.DTO
{
    public class NombreStats_DTO
    {
        public int? Id { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public int NombreCreationsComptes { get; set; }
        public int NombreCreationsPosts { get; set; }
        public int NombreCreationsCommentaires { get; set; }
        public int NombreCreationsLikes { get; set; }
        public int MoyenneLikesPosts { get; set; }
        public int MoyenneCommentairesPosts { get; set; }
        public List<CompteDTO_DTO> ComptesPostantLePlus { get; set; }
        public List<CompteDTO_DTO> ComptesCommentantLePlus { get; set; }
        public List<PostDTO_DTO> PostsLesPlusLikes { get; set; }
        public List<PostDTO_DTO> PostsLesPlusSuperLikes { get; set; }
        public List<PostDTO_DTO> PostsLesPlusCommentes { get; set; }
    }
}
