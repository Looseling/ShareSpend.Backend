namespace ShareSpend.Domain.Entities.DTOs.Input;

public class ReceiptDto
{
    public string ContainerId { get; set; }
    public string UserId { get; set; }
    public byte[] Image { get; set; }
}