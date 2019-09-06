using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EfCoreProblemWithDDD
{
    public class ExpenseType : Entity
    {
        public String Name { get; private set; }

        private ExpenseType()
        {
        }

        private ExpenseType(Int32 id, String name) : this()
        {
            Id = id;
            Name = name;
        }

        public static readonly ExpenseType Hobby = new ExpenseType(1, "Hobby");
        public static readonly ExpenseType Food = new ExpenseType(2, "Food");
        public static readonly ExpenseType Bills = new ExpenseType(3, "Bills");

        public class Map : IEntityTypeConfiguration<ExpenseType>
        {
            public void Configure(EntityTypeBuilder<ExpenseType> builder)
            {
                builder.HasData(Bills, Food, Hobby);
            }
        }
    }
}