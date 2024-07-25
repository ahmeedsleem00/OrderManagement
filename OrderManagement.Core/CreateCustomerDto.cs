using System.ComponentModel.DataAnnotations;

namespace Order_Management.Dto
{
    public class CreateCustomerDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
