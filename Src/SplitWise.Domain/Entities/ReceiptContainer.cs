using System.ComponentModel.DataAnnotations;

namespace ShareSpend.Domain.Entities;

public class ReceiptContainer
{
    [Key]
    public int Id { get; set; }

    public string ContainerName { get; set; }
    public string Description { get; set; }

    public List<Receipt> Receipts { get; set; }

    public List<UserReceiptContainer> UserReceiptContainers
    { get; set; }
}