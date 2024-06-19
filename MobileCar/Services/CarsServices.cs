using MobileCar.Data;
using MobileCar.Models;

namespace MobileCar.Services
{
    public class CarsServices : ICarsServices
    {
        public readonly ApplicationDbContext context;
        public CarsServices(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IEnumerable<AddCarViewModel> GetAll()
        {
            var cars = context.Cars
                            .Select(x => new AddCarViewModel
                             {
                                Id = x.Id,
                                 Name = x.Name,
                                 Price = x.Price,
                                 Kilometers = x.Kilometers,
                                 ImageUrl = x.ImageUrl,
                             }).ToList();
            return cars;
        }
    }
}
