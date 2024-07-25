using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order_Management.Dto;
using Order_Management.Errors;
using OrderManagement.Core.Entities;
using OrderManagement.Services;
using System.Security.Claims;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrdersAsync();
            var MappedOrder = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(MappedOrder);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var order = await _orderService.GetOrderByIdAsync(orderId);
            if (order == null)
            {
                return BadRequest(error: new ApiResponse(statusCode: 400));
            }
            return Ok(order);

        }

        [HttpPost]
        public async Task<ActionResult> CreateOrder(Order createOrderDto)
        {
           

            if (createOrderDto == null)
            {
                return BadRequest(error: new ApiResponse(statusCode: 400));
            }
            var order = new Order
            {
                CustomerId = createOrderDto.CustomerId,
                OrderDate = DateTime.UtcNow,
                TotalAmount = createOrderDto.TotalAmount,
                PaymentMethod = createOrderDto.PaymentMethod,
                OrderItems = createOrderDto.OrderItems.Select(oi => new OrderItem
                {
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                    UnitPrice = oi.UnitPrice,
                    Discount = 0

                }).ToList()
            };
            await _orderService.CreateOrderAsync(order);

            return Ok(order);

        }

          [HttpPut("{orderId}/status")]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] OrderStatus status)
        {
            await _orderService.UpdateOrderStatusAsync(orderId, status);
            return Ok();
        } 
    }
}
