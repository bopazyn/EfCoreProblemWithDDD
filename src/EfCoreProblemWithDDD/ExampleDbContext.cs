using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EfCoreProblemWithDDD
{
    public class ExampleDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<ExpenseType> ExpenseTypes { get; set; }

        public ExampleDbContext(DbContextOptions options) : base(options)
        {
        }

        public override Int32 SaveChanges(Boolean acceptAllChangesOnSuccess)
        {
            AttachRange(ChangeTracker.Entries<ExpenseType>().Select(x => x.Entity));
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExampleDbContext).Assembly);
        }
    }
}