using System.Diagnostics;
using CarSalesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesWeb.Controllers
{
    public class HomeController : Controller
    {

        //So this i where i created the objects for the cars to be displayed on the index page.
        public IActionResult Index()
        {

            

            Car car1 = new Car
            {

                CarID = 1,
                Manufacturer = "Nissan",
                Model = "370z",
                Year = 2010,
                Price = 20000,
                Odometer = 100000,
                Category = "sports",
                Image = "image"
            };

            Car car2 = new Car
            {

                CarID = 2,
                Manufacturer = "Mitsubishi",
                Model = "Evolution V",
                Year = 1999,
                Price = 60000,
                Odometer = 98000,
                Category = "sports rally",
                Image = "image"
            };

            Car car3 = new Car
            {

                CarID = 3,
                Manufacturer = "Subaru",
                Model = "Impreza WRX STI",
                Year = 2001,
                Price = 80000,
                Odometer = 50000,
                Category = "sports Rally",
                Image = "image"
            };

            var Carlist = new List<Car> { };
            Carlist.Add(car1);
            Carlist.Add(car2);
            Carlist.Add(car3);

            return View(Carlist);

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
