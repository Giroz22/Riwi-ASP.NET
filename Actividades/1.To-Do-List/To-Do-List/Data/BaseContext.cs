using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;

namespace ToDoApi.Data
{
    public class BaseContext : DbContext
    {

         // We overwrite the OnModelCreating method to add the Soft Delete global filter
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Exclude Tasks that are "deleted" (soft deleted)
            modelBuilder.Entity<TaskEntity>().HasQueryFilter(p => !p.Deleted);
        }

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {}        

        //Our models
        public DbSet<TaskEntity> Tasks {get; set;}
    }
}