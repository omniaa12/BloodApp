using BloodApp.Infrastructure.DataBase;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        #region Context Constructor
        private readonly Context _context;

        public StatisticsController(Context context)
        {
            _context = context;
        }
        #endregion

        #region Get Statistics
        [HttpGet]
        public IActionResult GetStatistics()
        {
            var donorsCount = _context.Donors.Count();

            var banksCount = _context.BloodBanks.Count();

            var patientsCount = _context.PatientVisits.Count();

            var availableBloodUnits = _context.InventorySummaries
                .Where(i => i.CurrentCount > 0)
                .Sum(i => i.CurrentCount);

            var result = new
            {
                متبرع_نشط = donorsCount,
                بنوك_الدم = banksCount,
                حالات_تم_انقاذها = patientsCount,
                وحدات_الدم_المتاحه = availableBloodUnits
            };

            return Ok(result);
        }
        #endregion
    }
}
