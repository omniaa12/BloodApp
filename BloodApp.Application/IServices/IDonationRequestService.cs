using BloodApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Application.IServices
{
    public interface IDonationRequestService
    {
        Task<bool> CreateAsync(int donorId, CreateDonationRequestDTO dto);
    }
}
