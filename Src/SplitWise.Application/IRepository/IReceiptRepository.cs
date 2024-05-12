using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptRepository
    {
        Task<Receipt> GetReceipt(int id);

        Task AddReceipt(Receipt receipt);

        Task UpdateReceipt(Receipt receipt);

        Task DeleteReceipt(int id);
    }
}