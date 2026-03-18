using BloodApp.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.Models
{
    public class InventorySummary
    {
        public int Id { get; set; }
        public int BankId { get; set; }
        public BloodType BloodGroup { get; set; }
        public string ComponentType { get; set; } = ""; // Plasma / RBCs / Whole
        public int CurrentCount { get; set; }
        public int AlertThreshold { get; set; } = 5; // لو قل عن 5 يدي إنذار

      
        public virtual BloodBank Bank { get; set; } = null!;
    }
}
