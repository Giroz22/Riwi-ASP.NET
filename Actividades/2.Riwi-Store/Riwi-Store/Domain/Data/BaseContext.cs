using Microsoft.EntityFrameworkCore;
using RiwiStore.Domain.Entities;

namespace RiwiStore.Domain.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {}        

        //Entities
        public DbSet<OrderEntity> Orders {get; set;}
        public DbSet<ProductEntity> Products {get; set;}
        public DbSet<UserEntity> Users {get; set;}
        public DbSet<PurchaseEntity> Purchases { get; set; }        

        //Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User to Purchase
            modelBuilder.Entity<UserEntity>()
                .HasMany(user=>user.Purchases)
                .WithOne(pur=>pur.User)
                .HasForeignKey(pur=>pur.UserId);

            //Purchase to order
            modelBuilder.Entity<PurchaseEntity>()
                .HasMany(pur=>pur.Orders)
                .WithOne(ord=>ord.Purchase)
                .HasForeignKey(ord=>ord.PurchaseId);

            //Product to product
            modelBuilder.Entity<ProductEntity>()
                .HasMany(prod=>prod.Orders)
                .WithOne(ord=>ord.Product)
                .HasForeignKey(ord=>ord.ProductId)
                .OnDelete(DeleteBehavior.SetNull); 
        }
    }
}