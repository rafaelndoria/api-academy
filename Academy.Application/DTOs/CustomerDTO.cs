using System.ComponentModel.DataAnnotations;

namespace Academy.Application.DTOs
{
    public class CustomerDTO
    {
        [Required(ErrorMessage = "The name is required")]
        [MaxLength(50, ErrorMessage = "Max length for name is 50")]
        [MinLength(2, ErrorMessage = "Min length for name is 3")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The phone number is required")]
        [MaxLength(11, ErrorMessage = "Max phone number is 11")]
        [MinLength(11, ErrorMessage = "Min phone number is 11")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "The email is required")]
        [MaxLength(100, ErrorMessage = "Max length for email is 100")]
        [MinLength(5, ErrorMessage = "Max length for email is 5")]
        [EmailAddress(ErrorMessage = "The email is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "The CPF is required")]
        [MaxLength(11, ErrorMessage = "Max length for cpf is 11")]
        [MinLength(11, ErrorMessage = "Min length for cpf is 11")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "The plan id is required")]
        public int PlanId { get; set; }
    }
}
