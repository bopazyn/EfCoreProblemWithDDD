using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreProblemWithDDD
{
    public class Expense : Entity
    {
        public ExpenseType Type { get; private set; }
        public Int32 Value { get; private set; }

        private Expense()
        {
        }

        public Expense(ExpenseType type, Int32 value) : this()
        {
            Type = type;
            Value = value;
        }


        public void SetType(ExpenseType type) => Type = type;

        public class Map : IEntityTypeConfiguration<Expense>
        {
            public void Configure(EntityTypeBuilder<Expense> builder)
            {
            }
        }
    }
}