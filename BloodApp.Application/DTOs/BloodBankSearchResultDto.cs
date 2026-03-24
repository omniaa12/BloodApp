using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Application.DTOs
{
    public class BloodBankSearchResultDto
    {
        public int BankId { get; set; }
        public string BankName { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }
    }
}
