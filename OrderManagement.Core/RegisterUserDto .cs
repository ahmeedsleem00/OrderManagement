using System.ComponentModel.DataAnnotations;

namespace Order_Management.Dto
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [RegularExpression(pattern: "(?=^.{6,10}$)(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%&amp;*()_+]).*$",
            ErrorMessage = "Password Must Be Contains at Least One Lowercase,One Uppercase,One Digit,One Special Character !")]
        public string Password { get; set; }
    }
}
