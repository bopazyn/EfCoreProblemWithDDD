using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace EfCoreProblemWithDDD.Tests
{
    public class Tests
    {
        
        [Fact]
        public void Test1()
        {
            var exampleDbContextFactory = new ExampleDbContextFactory();

            using (var dbContext = exampleDbContextFactory.CreateDbContext(new String[0]))
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }

            using (var dbContext = exampleDbContextFactory.CreateDbContext(new String[0]))
            {
                dbContext.Expenses.Add(new Expense(ExpenseType.Hobby, 11));
                dbContext.Expenses.Add(new Expense(ExpenseType.Bills, 22));
                dbContext.Expenses.Add(new Expense(ExpenseType.Food, 33));
                dbContext.SaveChanges();
            }

            using (var dbContext = exampleDbContextFactory.CreateDbContext(new String[0]))
            {
                var savedExpenses = dbContext.Expenses
                    .Include(x => x.Type)
                    .ToArray();

                foreach (var savedExpense in savedExpenses)
                {
                    savedExpense.SetType(ExpenseType.Bills);
                }
                dbContext.SaveChanges();
            }
        }
    }
}