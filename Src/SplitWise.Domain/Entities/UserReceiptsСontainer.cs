using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class UserReceiptContainer
{
    [Key]
    public int Id { get; set; }

    // Foreign keys
    [ForeignKey("User")]
    public int UserId { get; set; }

    [ForeignKey("ReceiptContainer")]
    public int ReceiptContainerId { get; set; }

    // Navigation properties
    public User User { get; set; }

    public ReceiptContainer ReceiptContainer { get; set; }
}