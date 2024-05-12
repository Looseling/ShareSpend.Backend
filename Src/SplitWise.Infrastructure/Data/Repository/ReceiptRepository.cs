using Microsoft.EntityFrameworkCore;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Infrastructure.Data.Repository
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly AppDbContext _context;

        public ReceiptRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddReceipt(Receipt receipt)
        {
            _context.Add(receipt);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReceipt(int id)
        {
            var receipt = _context.Receipts.Find(id);
            if (receipt != null)
            {
                _context.Remove(receipt);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Receipt> GetReceipt(int id)
        {
            return await _context.Receipts.FindAsync(id);
        }

        public async Task UpdateReceipt(Receipt receipt)
        {
            _context.Entry(receipt).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}