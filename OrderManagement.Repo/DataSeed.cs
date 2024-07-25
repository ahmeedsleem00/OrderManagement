using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Repo
{
    public static class DataSeed
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Seed Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Name = "Coffee", Price = 2.99M, Stock = 100 },
                new Product { ProductId = 2, Name = "Tea", Price = 1.99M, Stock = 200 },
                new Product { ProductId = 3, Name = "Cake", Price = 4.99M, Stock = 50 },
                new Product { ProductId = 4, Name = "Cookie", Price = 0.99M, Stock = 300 }
            );

            // Seed Customers
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Doe", Email = "john.doe@example.com" },
                new Customer { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com" }
            );

            // Seed Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now, TotalAmount = 10.97M, PaymentMethod = "Credit Card", Status = OrderStatus.PaymentReceived },
                new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now, TotalAmount = 5.98M, PaymentMethod = "PayPal", Status = OrderStatus.Pending }
            );

            // Seed OrderItems
            modelBuilder.Entity<OrderItem>().HasData(
                new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 2.99M, Discount = 0 },
                new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 4, Quantity = 2, UnitPrice = 0.99M, Discount = 0 },
                new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 2, Quantity = 3, UnitPrice = 1.99M, Discount = 0 }
            );

            // Seed Invoices
            modelBuilder.Entity<Invoice>().HasData(
                new Invoice { InvoiceId = 1, OrderId = 1, InvoiceDate = DateTime.Now, TotalAmount = 10.97M },
                new Invoice { InvoiceId = 2, OrderId = 2, InvoiceDate = DateTime.Now, TotalAmount = 5.98M }
            );

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "User" }
            );
        }
    }
}
