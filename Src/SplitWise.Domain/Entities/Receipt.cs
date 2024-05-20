using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class Receipt
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string MerchantName { get; set; }

    public string Address { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public DateTime Date { get; set; }

    public int ReceiptImageId { get; set; }

    //Foreign Keys
    [ForeignKey("ReceiptContainerId")]
    public int? ReceiptContainerId { get; set; }

    [ForeignKey("User")]
    public int UserId { get; set; }

    //Navigation properties
    public User User { get; set; }

    public ReceiptContainer ReceiptContainer { get; set; }

    public List<ReceiptItem> Items { get; set; }
}