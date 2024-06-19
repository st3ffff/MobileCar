using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MobileCar.Data;
using MobileCar.Models;
using MobileCar.Models.Entities;
using MobileCar.Services;

namespace MobileCar.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICarsServices service;

        public CarsController(ApplicationDbContext dbContext, ICarsServices service)
        {
            this.dbContext = dbContext;
            this.service = service;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddCarViewModel viewModel)
        {

            var car = new Car
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Kilometers = viewModel.Kilometers,
                ImageUrl = viewModel.ImageUrl,

            };

            await dbContext.Cars.AddAsync(car);
            await dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(CarsController.List), "Cars");

        }

        [HttpGet]
        public IActionResult List(string searchString)
        {

            var cars = service.GetAll();

            if (searchString != null)
            {
                cars = cars.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            return View(cars);

        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            var  car = await dbContext.Cars.FindAsync(id);

            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Car viewModel)
        {
            var car = await dbContext.Cars.FindAsync(viewModel.Id);

            if (car is not null)
            {
                car.Name = viewModel.Name;
                car.Price = viewModel.Price;
                car.Kilometers = viewModel.Kilometers;
                car.ImageUrl = viewModel.ImageUrl;

                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Cars");         
        }

        [HttpPost]

        public async Task<IActionResult> Delete(Car viewModel)
        {
            var car = await dbContext.Cars
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == viewModel.Id);

            if (car is not null)
            {
                dbContext.Cars.Remove(viewModel);
                await dbContext.SaveChangesAsync();
            }

            return RedirectToAction(nameof(CarsController.List), "Cars");


        }

    }
}
