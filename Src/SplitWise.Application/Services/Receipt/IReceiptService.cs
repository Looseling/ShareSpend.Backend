using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using ShareSpend.Domain.Entities;

namespace ShareSpend.Application.Services.Receipt
{
    public interface IReceiptService
    {
        Task<ReceiptServiceModel> ProcessReceipt(string containerId, byte[] image);
    }

    public record ReceiptServiceModel(
            string receiptUUID,
            string receiptContainerUUID,
            ProcessedReecipt receiptData);
}