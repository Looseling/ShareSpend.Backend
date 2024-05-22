using ShareSpend.Domain.Entities;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptImageStorage
    {
        Task SaveReceiptAsync(Storage receiptStorageModel);

        Task<Storage> GetReceiptAsync(string receiptContainerId, string receiptId);
    }
}