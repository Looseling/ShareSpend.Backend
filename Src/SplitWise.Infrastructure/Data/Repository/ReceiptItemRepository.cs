using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Infrastructure.Data.Repository
{
    public class ReceiptItemRepository : IReceiptItemRepository
    {
        private readonly AppDbContext _context;

        public ReceiptItemRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReceiptItem(ReceiptItem receiptItem)
        {
            _context.Add(receiptItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceiptItem(int id)
        {
            var receiptItem = _context.ReceiptItems.Find(id);
            if (receiptItem != null)
            {
                _context.Remove(receiptItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<ReceiptItem> GetReceiptItem(int id)
        {
            return await _context.ReceiptItems.FindAsync(id);
        }

        public async Task UpdateReceiptItem(ReceiptItem receiptItem)
        {
            _context.Entry(receiptItem).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}