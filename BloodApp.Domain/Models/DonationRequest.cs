using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodApp.Domain.Models;

public class DonationRequest
{
    public int Id { get; set; }

    public int DonorId { get; set; }
    [ForeignKey("DonorId")]
    public virtual Donor Donor { get; set; } = null!;

    public int BankId { get; set; }
    [ForeignKey("BankId")]
    public virtual BloodBank Bank { get; set; } = null!;

    public DateTime RequestDate { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Pending";
}