using BloodApp.Application.Enums;
using BloodApp.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodApp.Domain.Models;

public class InventorySummary
{
    public int Id { get; set; }

    public int BankId { get; set; }
    [ForeignKey("BankId")]
    public virtual BloodBank Bank { get; set; } = null!;

    public BloodType BloodGroup { get; set; }
    public string ComponentType { get; set; } = string.Empty;
    public int CurrentCount { get; set; }
    public int AlertThreshold { get; set; } = 5;
}