using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodApp.Application.DTOs
{
    public class DonorLoginDto
    {
        [Required(ErrorMessage = "الرقم القومي مطلوب")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "الرقم القومي يجب أن يكون 14 رقم")]
        public string NationalId { get; set; } = string.Empty;
    }
}
