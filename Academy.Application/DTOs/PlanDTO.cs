using System.ComponentModel.DataAnnotations;

namespace Academy.Application.DTOs
{
    public class PlanDTO
    {
        [Required(ErrorMessage = "The name is required")]
        [MinLength(3, ErrorMessage = "The min name must be 3")]
        [MaxLength(50, ErrorMessage = "The max name must be 50")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The price is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The price must be greater than 0")]
        public double Price { get; set; }

        [Required(ErrorMessage = "The entries per day is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The entry per day must be greater than 0")]
        public int EntriesPerDay { get; set; }

        [Required(ErrorMessage = "The type plan id is required")]
        [Range(1, int.MaxValue, ErrorMessage = "The plan type id must be greater than 0")]
        public int PlanTypeId { get; set; }
    }
}
