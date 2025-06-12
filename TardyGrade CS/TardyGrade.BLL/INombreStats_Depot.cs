
namespace TardyGrade.BLL
{
    public interface INombreStats_Depot<T>
    {
         IEnumerable<T> GetAll();
         T GetByDates(DateTime dateDebut, DateTime dateFin);
         Boolean Delete(int Id, DateTime dateDebut, DateTime dateFin);
    }
}