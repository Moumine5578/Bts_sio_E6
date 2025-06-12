using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    public class CompteDTO_DAL_API
    {
        public int? Id { get; set; }
        public int DateId { get; set; }
        public string Pseudo { get; private set; }
        public int NombrePosts { get; private set; }
        public int NombreCommentaires { get; private set; }


        #region Constructeurs
        public CompteDTO_DAL_API(int dateID, string pseudo, int nombrePosts, int nombreCommentaires)
        {
            this.DateId = dateID;
            this.Pseudo = pseudo;
            this.NombrePosts = nombrePosts;
            this.NombreCommentaires = nombreCommentaires;
        }

        public CompteDTO_DAL_API(int? id, int dateID, string pseudo, int nombrePosts, int nombreCommentaires)
        {
            this.Id = id;
            this.DateId = dateID;
            this.Pseudo = pseudo;
            this.NombrePosts = nombrePosts;
            this.NombreCommentaires = nombreCommentaires;
        }

        #endregion
    }
}
