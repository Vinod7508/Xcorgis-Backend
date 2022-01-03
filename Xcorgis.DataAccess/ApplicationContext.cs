using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using XCorgis.Domain.Entities;

namespace Xcorgis.DataAccess
{
    public class ApplicationContext : DbContext
    {
     public ApplicationContext(DbContextOptions options)
     : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //department_modelbuilder
            modelBuilder.Entity<Department>()
                        .ToTable("Departments");
            modelBuilder.Entity<Department>()
             .HasKey(d => d.Id);
            modelBuilder.Entity<Department>()
                        .HasMany(d => d.Products);
            modelBuilder.Entity<Department>()
                .Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(50);
            modelBuilder.Entity<Department>()
                .Property(d => d.AdditionalInformation)
                .HasMaxLength(200);
            modelBuilder.Entity<Department>()
                .Property(d => d.isActive)
                .HasDefaultValue(true);

            //product_modelBuilder
            modelBuilder.Entity<Product>()
                        .ToTable("Products")
                        .HasKey(p => p.ProductId);

            modelBuilder.Entity<Product>()
                .Property(p => p.ProductDesc)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Product>()
                .Property(p => p.isActive)
                .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
                .Property(p => p.Allow_Web_Sales)
                .HasDefaultValue(true);


            modelBuilder.Entity<Department>()
            .HasData(
                 new Department
                 {
                     Id = 1,
                     DepartmentName = "Mens",
                     AdditionalInformation = "Mens Special",
                 },
                 new Department
                 {
                     Id = 2,
                     DepartmentName = "Woman",
                     AdditionalInformation = "Woman Special",
                 });

            modelBuilder.Entity<Product>()
         .HasData(
              new Product
              {
                  ProductId = 1,
                  ProductDesc = "T-shit",
                  Price = 8.0,
                  DepartmentId = 1
              },
              new Product
              {
                  ProductId = 2,
                  ProductDesc = "Booties",
                  Price = 30.0,
                  DepartmentId = 2
              });



        }

        public DbSet<Department> Departments { get; set; }
         



    }


}
