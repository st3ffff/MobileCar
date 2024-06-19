using System.ComponentModel.DataAnnotations;

namespace MobileCar.Models.Entities
{
    public class Car
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Kilometers { get; set; }
        public string? ImageUrl { get; set; }
    }
}
