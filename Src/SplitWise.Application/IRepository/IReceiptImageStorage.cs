using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptImageStorage
    {
        Task SaveReceiptAsync(ReceiptStorageModel receiptStorageModel);

        Task<ReceiptStorageModel> GetReceiptAsync(string receiptContainerId, string receiptId);
    }
}