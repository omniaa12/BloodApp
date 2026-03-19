using System.ComponentModel.DataAnnotations;

namespace BloodApp.Domain.Models;

public class BloodBank
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    [Required, Phone, StringLength(11, MinimumLength = 11)]
    public string Phone { get; set; } = string.Empty;

    [Required, EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public virtual ICollection<BloodBag> BloodBags { get; set; } = new List<BloodBag>();
    public virtual ICollection<Donor> Donors { get; set; } = new List<Donor>();
    public virtual ICollection<DonationRequest> DonationRequests { get; set; } = new List<DonationRequest>();
    public virtual ICollection<PatientVisit> PatientVisits { get; set; } = new List<PatientVisit>();
    public virtual ICollection<InventorySummary> InventorySummaries { get; set; } = new List<InventorySummary>();
}