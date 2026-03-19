using BloodApp.Application.Enums;
using BloodApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodApp.Domain.Models;

public class Donor
{
    public int Id { get; set; }

    [Required, RegularExpression(@"^[0-9]{14}$", ErrorMessage = "الرقم القومي يجب أن يكون 14 رقم")]
    public string NationalId { get; set; } = string.Empty;

    [Required, StringLength(100, MinimumLength = 3, ErrorMessage = "الاسم غير صالح")]
    public string FullName { get; set; } = string.Empty;

    public Egender Gender { get; set; }
    public DateOnly BirthDate { get; set; }
    public BloodType? BloodGroup { get; set; }

    [Required, Phone, StringLength(11, MinimumLength = 11)]
    public string Phone { get; set; } = string.Empty;

    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    public string Governrate { get; set; } = string.Empty;
    public bool IsHealthy { get; set; } = true;
    public DateTime? LastDonationDate { get; set; }

    public int BankId { get; set; }
    [ForeignKey("BankId")]
    public virtual BloodBank Bank { get; set; } = null!;

    public virtual ICollection<DonationRequest> DonationRequests { get; set; } = new List<DonationRequest>();
    public virtual ICollection<BloodBag> BloodBags { get; set; } = new List<BloodBag>();
}