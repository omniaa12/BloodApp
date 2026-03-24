using BloodApp.Application.DTOs;
using BloodApp.Application.IServices;
using BloodApp.Domain.IRepositories;
using BloodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Application.Services
{
    public class DonationRequestService : IDonationRequestService
    {
        private readonly IDonationRequestRepository _repository;
        private readonly IDonorRepository _donorRepository;

        public DonationRequestService(
            IDonationRequestRepository repository,
            IDonorRepository donorRepository)
        {
            _repository = repository;
            _donorRepository = donorRepository;
        }

        public async Task<bool> CreateAsync(int donorId, CreateDonationRequestDTO dto)
        {
            var donor = await _donorRepository.GetByIdAsync(donorId);
            if (donor == null) return false;

            var request = new DonationRequest
            {
                DonorId = donorId,
                BankId = dto.BankId,
                Status = "Pending",
                RequestDate = DateTime.Now
            };

            await _repository.AddAsync(request);
            return true;
        }
    }
}
