using BloodApp.Application.DTOs;
using BloodApp.Domain.Models;

namespace BloodApp.Application.IServices
{
    public interface IDonorService
    {
        Task<Donor?> GetProfileAsync(int id);
        Task<bool> UpdateProfileAsync(int id, UpdateDonorDTO dto);
    }
}
