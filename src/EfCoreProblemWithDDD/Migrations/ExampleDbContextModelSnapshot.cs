﻿// <auto-generated />
using System;
using EfCoreProblemWithDDD;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EfCoreProblemWithDDD.Migrations
{
    [DbContext(typeof(ExampleDbContext))]
    partial class ExampleDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EfCoreProblemWithDDD.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("TypeId");

                    b.Property<int>("Value");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("EfCoreProblemWithDDD.ExpenseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExpenseTypes");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Name = "Bills"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Food"
                        },
                        new
                        {
                            Id = 1,
                            Name = "Hobby"
                        });
                });

            modelBuilder.Entity("EfCoreProblemWithDDD.Expense", b =>
                {
                    b.HasOne("EfCoreProblemWithDDD.ExpenseType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeId");
                });
#pragma warning restore 612, 618
        }
    }
}
