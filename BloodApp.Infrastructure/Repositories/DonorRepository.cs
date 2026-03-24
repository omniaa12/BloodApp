using BloodApp.Domain.IRepositories;
using BloodApp.Domain.Models;
using BloodApp.Infrastructure.DataBase;

namespace BloodApp.Infrastructure.Repositories
{
    public class DonorRepository : IDonorRepository
    {
        private readonly Context _context;
        public DonorRepository(Context context)
        {
            _context = context;
        }
        public async Task<Donor?> GetByIdAsync(int id)
        {
            return await _context.Donors.FindAsync(id);
        }

        public Task UpdateAsync(Donor donor)
        {
            throw new NotImplementedException();
        }
    }
}
