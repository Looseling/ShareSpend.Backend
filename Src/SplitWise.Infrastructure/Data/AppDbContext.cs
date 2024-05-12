using Microsoft.EntityFrameworkCore;
using ShareSpend.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ShareSpend.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ReceiptItem> ReceiptItems { get; set; }
        public DbSet<ReceiptContainer> ReceiptContainers { get; set; }
        public DbSet<UserReceiptContainer> UserReceiptContainers { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure many-to-many relationship
            modelBuilder.Entity<UserReceiptContainer>()
                .HasKey(uc => new { uc.UserId, uc.ReceiptContainerId });

            modelBuilder.Entity<UserReceiptContainer>()
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserReceiptContainers)
                .HasForeignKey(uc => uc.UserId);

            modelBuilder.Entity<UserReceiptContainer>()
                .HasOne(uc => uc.ReceiptContainer)
                .WithMany(c => c.UserReceiptContainers)
                .HasForeignKey(uc => uc.ReceiptContainerId);
        }
    }
}