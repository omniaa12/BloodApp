using BloodApp.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.Models
{
    public class BloodBag
    {
        public string BagSerial { get; set; } = "";
        public int DonorId { get; set; }
        public int BankId { get; set; }
        public BloodType BloodGroup { get; set; }
        public string ComponentType { get; set; } = ""; // Plasma / RBCs / Whole
        public DateTime CollectionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public BagStatus Status { get; set; } = BagStatus.Available;

        public int? PatientVisitId { get; set; } // هيبقي نل لو محدش خده لسة


        public Donor Donor { get; set; } = null!;
        public BloodBank Bank { get; set; } = null!;
    }
}
