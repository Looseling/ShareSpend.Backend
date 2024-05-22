using Microsoft.EntityFrameworkCore;
using ShareSpend.Application.IRepository;
using ShareSpend.Domain.Entities;


namespace ShareSpend.Infrastructure.Data.Repository
{
    public class ContainerRepository : IContainerRepository
    {
        private readonly AppDbContext _context;

        public ContainerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddContainer(Container receiptContainer)
        {
            _context.Add(receiptContainer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteContainer(string containerId)
        {
            var container = _context.Containers.FirstOrDefaultAsync(c => c.PublicId == containerId);
            if (container != null)
            {
                _context.Remove(container);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Container> GetContainer(string containerId)
        {
            return await _context.Containers.FirstOrDefaultAsync(c => c.PublicId == containerId);
        }

        public async Task<bool> IsContainerExists(string containerId)
        {
            return await _context.Containers.AnyAsync( c => c.PublicId == containerId);
        }

        public async Task UpdateContainer(Container receiptContainer)
        {
            _context.Entry(receiptContainer).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}