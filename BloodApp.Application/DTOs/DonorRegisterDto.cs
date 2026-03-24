using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BloodApp.Application.DTOs
{
    public class DonorRegisterDto
    {
        [Required(ErrorMessage = "الرقم القومي مطلوب")]
        [RegularExpression(@"^[0-9]{14}$", ErrorMessage = "الرقم القومي يجب أن يكون 14 رقم")]
        public string NationalId { get; set; } = string.Empty;

        [Required(ErrorMessage = "الاسم بالكامل مطلوب")]
        [StringLength(100, MinimumLength = 3)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "رقم الهاتف مطلوب")]
        [Phone]
        [StringLength(11, MinimumLength = 11)]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }

        
        public string? BloodGroup { get; set; }

        [Required(ErrorMessage = "المحافظة مطلوبة")]
        public string Governorate { get; set; } = string.Empty;

        public DateOnly BirthDate { get; set; }

        public String Gender { get; set; } = string.Empty;
    }
}
