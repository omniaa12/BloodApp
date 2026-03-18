using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.Models
{
    public class DonationRequest
    {
        public int Id { get; set; }
        public int DonorId { get; set; }
        public int BankId { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Pending"; // Pending|Approved|Cancelled|Completed



        
        public virtual Donor Donor { get; set; } = null!;
        public virtual BloodBank Bank { get; set; } = null!;
    }
}
