using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    public class PostDTO_DAL_API
    {
        public int? Id { get; set; }
        public int DateId { get; set; }
        public int Id_Post { get; private set; }
        public string Titre { get; private set; }
        public string PseudoAuteur { get; private set; }
        public DateTime DatePublication { get; private set; }
        public int NombreLikes { get; private set; }
        public int NombreSuperLikes { get; private set; }
        public int NombreCommentaires { get; private set; }

        #region Constructeurs

        public PostDTO_DAL_API(int dateID, int id_Post, string titre, string pseudoAuteur, DateTime datePublication, int nombreLikes, int nombreSuperLikes, int nombreCommentaires)
        {
            this.DateId = dateID;
            this.Id_Post = id_Post;
            this.Titre = titre;
            this.PseudoAuteur = pseudoAuteur;
            this.DatePublication = datePublication;
            this.NombreLikes = nombreLikes;
            this.NombreSuperLikes = nombreSuperLikes;
            this.NombreCommentaires = nombreCommentaires;
        }

        public PostDTO_DAL_API(int? id, int dateID, int id_Post, string titre, string pseudoAuteur, DateTime datePublication, int nombreLikes, int nombreSuperLikes, int nombreCommentaires)
        {
            this.Id = id;
            this.DateId = dateID;
            this.Id_Post = id_Post;
            this.Titre = titre;
            this.PseudoAuteur = pseudoAuteur;
            this.DatePublication = datePublication;
            this.NombreLikes = nombreLikes;
            this.NombreSuperLikes = nombreSuperLikes;
            this.NombreCommentaires = nombreCommentaires;
        }

        #endregion
    }
}
