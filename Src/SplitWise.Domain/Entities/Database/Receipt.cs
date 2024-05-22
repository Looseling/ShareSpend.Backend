using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShareSpend.Domain.Entities;

public class Receipt
{
    public int Id { get; set; }

    public string? MerchantName { get; set; }
    public string? Address { get; set; }
    public string? PublicId { get; set; }
    public int ReceiptImageId { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal Total { get; set; }

    public DateTime Date { get; set; }

    public int UserId { get; set; }
    public User? User { get; set; }

    public int ReceiptContainerId { get; set; }
    public Container? ReceiptContainer { get; set; }

    public List<ReceiptItem>? Items { get; set; }
}