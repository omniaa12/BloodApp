using BloodApp.Application.DTOs;
using BloodApp.Application.IServices;
using Microsoft.AspNetCore.Mvc;

namespace BloodApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonorController : ControllerBase
    {
        private readonly IDonorService _donorService;
        public DonorController(IDonorService donorService)
        {
            _donorService = donorService;
        }
        [HttpGet("{id}/profile")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var donor = await _donorService.GetProfileAsync(id);
            if (donor == null) return NotFound();
            return Ok(donor);
        }
        [HttpPut("{id}/profile")]
        public async Task<IActionResult> UpdateProfile(int id, [FromBody] UpdateDonorDTO dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var result = await _donorService.UpdateProfileAsync(id, dto);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
