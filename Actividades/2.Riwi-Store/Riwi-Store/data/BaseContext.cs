using Microsoft.EntityFrameworkCore;
using RiwiStore.Model;

namespace RiwiStore.Data
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {}        

        //Entities
        public DbSet<OrderEntity> Orders {get; set;}
        public DbSet<ProductEntity> Products {get; set;}
        public DbSet<UserEntity> Users {get; set;}

        //Relations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //User to Order
            modelBuilder.Entity<UserEntity>()
                .HasMany(u=>u.Orders)
                .WithOne(o=>o.User)
                .HasForeignKey(o=>o.UserId);

            //Product to Order
            modelBuilder.Entity<ProductEntity>()
                .HasMany(p=>p.Orders)
                .WithOne(o=>o.Product)
                .HasForeignKey(o=>o.ProductId);
            
        }
    }
}