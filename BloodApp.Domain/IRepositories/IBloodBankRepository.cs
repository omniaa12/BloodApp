using BloodApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.IRepositories
{
    public interface IBloodBankRepository
    {
        Task<IEnumerable<BloodBankSearchResultDto>> SearchAvailableBloodAsync(string bloodType, string governorate);
    }
}
