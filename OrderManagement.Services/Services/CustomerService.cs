using Microsoft.EntityFrameworkCore;
using OrderManagement.Core.Entities;
using OrderManagement.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly OrderManagementDbContext _context;

        public CustomerService(OrderManagementDbContext context)
        {
            _context = context;
        }
       
       

      

        public async Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId)
        {
            return await _context.Orders
                      .Where(o => o.CustomerId == customerId)
                      .Include(o => o.OrderItems)
                      .ToListAsync();
        }

        public async Task<Customer> CreateCustomerAsync(Customer createDto)
        {
            var customer = new Customer()
            {
                Name = createDto.Name,
                Email = createDto.Email
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        Task ICustomerService.CreateCustomerAsync(Customer createDto)
        {
            throw new NotImplementedException();
        }
    }
}
