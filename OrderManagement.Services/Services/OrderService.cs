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
    public class OrderService : IOrderService
    {
        private readonly OrderManagementDbContext _context;

        public OrderService(OrderManagementDbContext context) 
        {
            _context = context;
        }

      

        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            return await _context.Orders
          .Include(o => o.OrderItems)
              .ThenInclude(oi => oi.Product)
          .ToListAsync();
        }

        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
           .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.Product)
           .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        public async Task<bool> UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            var order = await _context.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }

            order.Status = status;
            await _context.SaveChangesAsync();
            return true;
        }

      public  async Task<Order> CreateOrderAsync(Order order)
        {
            var Orders = new Order
            {
                CustomerId = order.CustomerId,
                OrderId = order.OrderId,
                PaymentMethod = order.PaymentMethod,
                Status = order.Status,
                OrderItems = order.OrderItems.Select(s => new OrderItem
                {
                    ProductId = s.ProductId,
                    Quantity = s.Quantity,
                    UnitPrice = s.UnitPrice,
                    Discount = 0
                }).ToList()

            };
            _context.Add(Orders);
            await _context.SaveChangesAsync();

            return order;
        }

        Task IOrderService.CreateOrderAsync(Order order)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateOrderStatusAsync(int orderId, string status)
        {
            throw new NotImplementedException();
        }

        Task IOrderService.UpdateOrderStatusAsync(int orderId, OrderStatus status)
        {
            throw new NotImplementedException();
        }
    }
}
