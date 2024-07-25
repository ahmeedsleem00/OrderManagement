namespace Order_Management.Dto
{
    public class CreateOrderDto
    {
        public int CustomerId { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public string PaymentMethod { get; set; }
    }
}
