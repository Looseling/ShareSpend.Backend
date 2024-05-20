using ShareSpend.Domain.Entities;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptImageProcessor
    {
        Task<ProcessedReecipt> GetDataFromReceipt(byte[] imageBytes);
    }
}