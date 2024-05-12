using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Application.IRepository
{
    public interface IReceiptContainerRepository
    {
        Task AddReceiptContainer(ReceiptContainer receiptContainer);

        Task<ReceiptContainer> GetReceiptContainer(int id);

        Task UpdateReceiptContainer(ReceiptContainer receiptContainer);

        Task DeleteReceiptContainer(int id);
    }
}