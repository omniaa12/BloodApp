using BloodApp.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Domain.Models
{
    public class PatientVisit
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = "";
        public string PatientPhone { get; set; } = "";
        public BloodType PatientBloodType { get; set; }
        public string CaseType { get; set; } = ""; // طوارئ / عملية
        public string RecipientName { get; set; } = ""; // اسم المستلم
        public DateTime VisitDate { get; set; }
        public int BankId { get; set; }



        //عشان المريض يقدر ياخد اكتر من كيس
        public ICollection<BloodBag> ConsumedBags { get; set; } = new List<BloodBag>();
    }
}
