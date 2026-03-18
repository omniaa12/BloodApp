using BloodApp.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string NationalId { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Gender { get; set; } = "";
        public DateOnly BirthDate { get; set; }
        public BloodType? BloodGroup { get; set; }
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string Governrate { get; set; } = "";
        public bool IsHealthy { get; set; } = true;
        public DateTime? LastDonationDate { get; set; }

        public ICollection<BloodBag> BloodBags { get; set; } = new List<BloodBag>();
    }
}
