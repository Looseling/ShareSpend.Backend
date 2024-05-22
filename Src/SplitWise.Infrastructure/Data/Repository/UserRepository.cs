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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUser(string publicId)
        {
            var user = _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);
            if (user != null)
            {
                _context.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> GetUserByIdAsync(string publicId)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.PublicId == publicId);
        }

        public async Task<bool> IsUserExists(string publicId)
        {
            return await _context.Users.AnyAsync(u => u.PublicId == publicId);
        }

        public async Task UpdateUser(User user)
        {
            _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}