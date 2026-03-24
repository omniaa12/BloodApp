using BloodApp.Application.Enums;
using BloodApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodApp.Domain.Models;

public class PatientVisit
{
    public int Id { get; set; }

    [Required]
    public string PatientName { get; set; } = string.Empty;

    [Phone, StringLength(11)]
    public string PatientPhone { get; set; } = string.Empty;

    public BloodType PatientBloodType { get; set; }
    public string CaseType { get; set; } = string.Empty;
    public string RecipientName { get; set; } = string.Empty;
    public DateTime VisitDate { get; set; }

    public int BankId { get; set; }
    [ForeignKey("BankId")]
    public virtual BloodBank BloodBank { get; set; } = null!;

    public virtual ICollection<BloodBag> ConsumedBags { get; set; } = new List<BloodBag>();
}