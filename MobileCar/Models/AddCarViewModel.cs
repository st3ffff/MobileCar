namespace MobileCar.Models
{
    public class AddCarViewModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public double Kilometers { get; set; }

        public string? ImageUrl { get; set; }

    }
}
