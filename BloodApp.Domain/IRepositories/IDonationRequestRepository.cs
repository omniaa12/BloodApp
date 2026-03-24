using BloodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.IRepositories
{
    public interface IDonationRequestRepository
    {
        Task AddAsync(DonationRequest request);
    }
}
