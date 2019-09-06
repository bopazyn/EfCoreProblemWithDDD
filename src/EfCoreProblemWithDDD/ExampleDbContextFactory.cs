using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EfCoreProblemWithDDD
{
    public class ExampleDbContextFactory : IDesignTimeDbContextFactory<ExampleDbContext>
    {
        public ExampleDbContext CreateDbContext(String[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ExampleDbContext>();
            optionsBuilder
                .UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Example;Integrated Security=True;MultipleActiveResultSets=True;");

            return new ExampleDbContext(optionsBuilder.Options);
        }
    }
}