using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class ReceiptItem
{
    public int Id { get; set; }

    public string? ItemName { get; set; }
    public double Quantity { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Discount { get; set; }

    public int ReceiptId { get; set; }
    public Receipt? Receipt { get; set; }
}