using MobileCar.Models;

namespace MobileCar.Services
{
    public interface ICarsServices
    {
        public IEnumerable<AddCarViewModel> GetAll();
    }
}
