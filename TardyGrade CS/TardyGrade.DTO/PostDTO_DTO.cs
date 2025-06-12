using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DTO
{
    public class PostDTO_DTO
    {
        public int? Id { get; set; }
        public int Id_Post { get; set; }
        public string Titre { get; set; }
        public string PseudoAuteur { get; set; }
        public DateTime DatePublication { get; set; }
        public int NombreLikes { get; set; }
        public int NombreSuperLikes { get; set; }
        public int NombreCommentaires { get; set; }
    }
}
