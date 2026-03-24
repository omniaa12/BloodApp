using BloodApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.IRepositories
{
    public interface IDonorRepository
    {
        Task<Donor?> GetByIdAsync(int id);
        Task UpdateAsync(Donor donor);
    }
}
