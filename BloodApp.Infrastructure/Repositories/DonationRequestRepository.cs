using BloodApp.Domain.IRepositories;
using BloodApp.Domain.Models;
using BloodApp.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Infrastructure.Repositories
{
    public class DonationRequestRepository : IDonationRequestRepository
    {
        private readonly Context _context;
        public DonationRequestRepository(Context context)
        {
            _context = context;
        }
        public async Task AddAsync(DonationRequest request)
        {
            await _context.DonationRequests.AddAsync(request);
            await _context.SaveChangesAsync();
        }
    }
}
