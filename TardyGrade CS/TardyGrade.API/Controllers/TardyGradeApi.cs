using Microsoft.AspNetCore.Mvc;
using TardyGrade.Services;
using TardyGrade.DTO;

namespace TardyGrade.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TardyGradeApi : ControllerBase
    {
        private readonly ILogger<TardyGradeApi> _logger;
        private NombreStats_Service _Service;

        public TardyGradeApi(ILogger<TardyGradeApi> logger, NombreStats_Service service)
        {
            _logger = logger;
            _Service = service;
        }

        [HttpGet("GetByDates")]
        public NombreStats_DTO GetByDates(DateTime DateDebut, DateTime DateFin)
        {
            return _Service.GetByDates(DateDebut, DateFin);
        }

        [HttpGet("GetAll")]
        public IEnumerable<NombreStats_DTO> GetAll()
        {
            return _Service.GetAll();
        }

        [HttpDelete("Delete")]
        public Boolean Delete(int Id, DateTime DateDebut, DateTime DateFin)
        {
            return _Service.Delete(Id, DateDebut, DateFin);
        }
    }
}
