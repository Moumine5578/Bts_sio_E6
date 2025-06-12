using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.BLL
{
    public class CompteDTO
    {
        public int? Id { get; private set; }
        public string Pseudo { get; private set; }
        public int NombrePosts { get; private set; }
        public int NombreCommentaires { get; private set; }

        #region Constructeurs
        public CompteDTO(string pseudo, int nombrePosts, int nombreCommentaires)
        {
            this.Pseudo = pseudo;
            this.NombrePosts = nombrePosts;
            this.NombreCommentaires = nombreCommentaires;
        }

        public CompteDTO(int? id, string pseudo, int nombrePosts, int nombreCommentaires)
        {
            this.Id = id;
            this.Pseudo = pseudo;
            this.NombrePosts = nombrePosts;
            this.NombreCommentaires = nombreCommentaires;
        }

        #endregion

    }
}
