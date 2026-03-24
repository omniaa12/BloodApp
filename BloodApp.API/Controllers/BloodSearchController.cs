using BloodApp.Domain.IRepositories;
using BloodApp.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BloodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodSearchController : ControllerBase
    {
        private readonly IBloodBankRepository _bloodBankRepo;
        public BloodSearchController(IBloodBankRepository repository)
        {
            _bloodBankRepo = repository;
        }

        [HttpGet("blood-banks-Search")]
        public async Task<IActionResult> SearchBlood([FromQuery] string? bloodType, [FromQuery] string? governorate)
        {
            var results = await _bloodBankRepo.SearchAvailableBloodAsync(bloodType ?? "", governorate ?? "");

            if (!results.Any())
                return Ok(new { Message = "لم يتم العثور على بنوك دم تحتوي على هذه الفصيلة حالياً", Data = results });

            return Ok(new { Message = "تمت عملية البحث بنجاح", Data = results });
        }
    }
}
