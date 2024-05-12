using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Infrastructure.Data.Repository
{
    public class ReceiptContainerRepository : IReceiptContainerRepository
    {
        private readonly AppDbContext _context;

        public ReceiptContainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReceiptContainer(ReceiptContainer receiptContainer)
        {
            _context.Add(receiptContainer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceiptContainer(int id)
        {
            var receiptContainer = _context.ReceiptContainers.Find(id);
            if (receiptContainer != null)
            {
                _context.Remove(receiptContainer);
                await _context.SaveChangesAsync();
            }
        }

        public Task<ReceiptContainer> GetReceiptContainer(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateReceiptContainer(ReceiptContainer receiptContainer)
        {
            _context.Entry(receiptContainer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}