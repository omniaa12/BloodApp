using BloodApp.Application.Enums;
using BloodApp.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodApp.Domain.Models;

public class BloodBag
{
    [Key]
    public string BagSerial { get; set; } = string.Empty;

    public int DonorId { get; set; }
    [ForeignKey("DonorId")]
    public virtual Donor Donor { get; set; } = null!;

    public int BankId { get; set; }
    [ForeignKey("BankId")]
    public virtual BloodBank Bank { get; set; } = null!;

    public BloodType BloodGroup { get; set; }
    public string ComponentType { get; set; } = string.Empty;
    public DateTime CollectionDate { get; set; }
    public DateTime ExpiryDate { get; set; }
    public BagStatus Status { get; set; } = BagStatus.Available;

    public int? PatientVisitId { get; set; }
    [ForeignKey("PatientVisitId")]
    public virtual PatientVisit? PatientVisit { get; set; }
}