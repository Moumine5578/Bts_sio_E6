using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TardyGrade.DAL.API
{
    internal interface IDepot_DAL_API<T_DAL>
    {
        T_DAL Insert(T_DAL entity);
        T_DAL? GetByDates(DateTime dateDebut, DateTime dateFin);
        IEnumerable<T_DAL> GetAll();
        Boolean Delete(int Id, DateTime dateDebut, DateTime dateFin);
    }
}
