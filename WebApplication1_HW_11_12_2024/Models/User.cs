using System.ComponentModel.DataAnnotations;

namespace WebApplication1_HW_11_12_2024.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; } 

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public int? Age { get; set; }

        [CreditCard]
        public string CreditCardNumber { get; set; }

        [Url]
        public string Website { get; set; }
    }
}
