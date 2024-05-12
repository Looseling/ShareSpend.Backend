using ShareSpend.Domain.Entities;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptItemRepository
    {
        Task AddReceiptItem(ReceiptItem receiptItem);

        Task<ReceiptItem> GetReceiptItem(int id);

        Task UpdateReceiptItem(ReceiptItem receiptItem);

        Task DeleteReceiptItem(int id);
    }
}