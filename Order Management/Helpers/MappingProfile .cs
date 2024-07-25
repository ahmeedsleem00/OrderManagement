using AutoMapper;
using Order_Management.Dto;
using OrderManagement.Core.Entities;
namespace Order_Management.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();

        }
    }
}
