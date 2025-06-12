using TardyGrade.DTO;

namespace TardyGrade.Services
{
    public interface INombreStats_Service<T>
    {
        IEnumerable<T> GetAll();
        T GetByDates(DateTime DateDebut, DateTime DateFin);
        Boolean Delete(int Id, DateTime DateDebut, DateTime DateFin);
    }
}