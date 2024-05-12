using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class ReceiptItem
{
    [Key]
    public int Id { get; set; }

    public string ItemName { get; set; }
    public double Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal? Discount { get; set; } // Optional

    //Foreign keys
    [ForeignKey("Receipt")]
    public int ReceiptId { get; set; }

    // Navigation property
    public Receipt Receipt { get; set; }
}