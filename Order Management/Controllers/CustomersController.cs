using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Order_Management.Dto;
using Order_Management.Errors;
using OrderManagement.Core.Entities;
using OrderManagement.Repo;
using OrderManagement.Services;
using System.Security.Claims;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;
        private readonly OrderManagementDbContext _context;

        public CustomersController(ICustomerService customerService , IMapper mapper)
        {
            _customerService = customerService;
            mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewCustomer([FromBody] CustomerDto customerDto)
        {
            if(customerDto == null)
            {
                return BadRequest(error: new ApiResponse(statusCode:400));
            }
            var customer = new Customer
            {
                Name = customerDto.Name,
                Email = customerDto.Email,
            };
            await _customerService.CreateCustomerAsync(customer);
            return Ok(customer);
        }

        [HttpGet("{customerId}/orders")]


        public async Task<IActionResult> GetOrdersByCustomerIdAsync(int customerId)
        {
            //var orders = await _customerService.GetCustomerOrdersAsync(customerId);

            //if (orders == null)
            //{
            //    return BadRequest(error: new ApiResponse(statusCode: 404));
            //}
            //var orderDtos = orders.Select(order => new OrderDto
            //{
            //    OrderId = order.OrderId,
            //    OrderDate = order.OrderDate,
            //    TotalAmount = order.TotalAmount,
            //    PaymentMethod = order.PaymentMethod,
            //    Status = order.Status
            //}).ToList();

            //return Ok(orders);




            var orders = await _customerService.GetCustomerOrdersAsync(customerId);
            if (orders == null || !orders.Any())
            {
                return NotFound();
            }

            var orderDtos = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return Ok(orderDtos);
        }



    }
}
