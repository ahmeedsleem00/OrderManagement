namespace Order_Management.Dto
{
    public class OrderDetailsDto
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDetailsDto> OrderItems { get; set; }
        public string PaymentMethod { get; set; }
        public string Status { get; set; }  
    }
}
