using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services
{
    public interface ICustomerService
    {
        Task CreateCustomerAsync(Customer createDto);
        Task<IEnumerable<Order>> GetCustomerOrdersAsync(int customerId);

    }
}
