using BloodApp.Application.DTOs;

using BloodApp.Domain.IRepositories;
using BloodApp.Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;

namespace BloodApp.Infrastructure.Repositories
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly Context _context;

        public BloodBankRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BloodBankSearchResultDto>> SearchAvailableBloodAsync(string bloodType, string governorate)
        {
            var query = _context.BloodBanks.AsQueryable();

            if (!string.IsNullOrWhiteSpace(governorate) && governorate != "ج    ميع المحافظات")
            {
                query = query.Where(b => b.Location == governorate);
            }

            if (!string.IsNullOrWhiteSpace(bloodType) && bloodType != "جميع الفصائل")
            {
                query = query.Where(b => b.InventorySummaries
                                          .Any(i => i.BloodGroup == bloodType && i.CurrentCount > 0));
            }

            return await query.Select(b => new BloodBankSearchResultDto
            {
                BankId = b.Id,
                BankName = b.Name,
                Governorate = b.Location,

                IsAvailable = b.InventorySummaries.Any(i => i.CurrentCount > 0)
            }).ToListAsync();
        }
    }
}