using BloodApp.Application.DTOs;
using BloodApp.Application.IServices;
using BloodApp.Domain.IRepositories;
using BloodApp.Domain.Models;

namespace BloodApp.Application.Services
{
    public class DonorService : IDonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<Donor> GetProfileAsync(int id)
        {
            return await _donorRepository.GetByIdAsync(id);
        }

        public async Task<bool> UpdateProfileAsync(int id, UpdateDonorDTO dto)
        {
            var donor = await _donorRepository.GetByIdAsync(id);
            if (donor == null) return false;

            donor.FullName = dto.FullName;
            donor.Email = dto.Email;
            donor.Phone = dto.Phone;

            await _donorRepository.UpdateAsync(donor);
            return true;
        }
    }
}
