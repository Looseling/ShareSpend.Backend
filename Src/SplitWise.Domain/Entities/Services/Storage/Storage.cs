namespace ShareSpend.Domain.Entities;

public class Storage
{
    public string? ReceiptContainerId { get; set; }
    public string? ReceiptId { get; set; }
    public byte[]? ReceiptImage { get; set; }
}