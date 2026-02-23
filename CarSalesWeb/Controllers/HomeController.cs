using CarSalesWeb.Data;
using CarSalesWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Runtime.CompilerServices;


namespace CarSalesWeb.Controllers
{


    public class HomeController : Controller
    {
        //Think of _context as the magic phone to call the database.
        private readonly CarDbContext _context;

        public HomeController(CarDbContext context)
        {
            _context = context;
        }

        //So this i where i created the objects for the cars to be displayed on the index page.

        //when the search is used in index the it will replace string search with the search term and can be used to filter the list of cars shown
        //Ive also now added sortOrder so now i can sort the cars, it checks for the parameter in the url from index
        public IActionResult Index(string search, string sortOrder)
        {
            //this is where i use the magic phone to call the database and get the list of cars,
            //i use asqueryable so that i can add filters to it before it is executed and the data is actually retrieved
            var carsQuery = _context.Cars.AsQueryable();

            //this was the same as before when i called it from a list but now im calling it from the database,
            //so i can use linq to filter the data before it is retrieved
            if (!string.IsNullOrEmpty(search))
            {
                carsQuery = carsQuery.Where(car =>
                 car.Manufacturer.Contains(search) ||
                 car.Model.Contains(search) ||
                 car.Category.Contains(search)
                 
                 );

            }
            //this is also the same as before but now im calling it from the database and using linq to sort
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "price_asc":
                        carsQuery = carsQuery.OrderBy(car => car.Price);
                        break;

                    case "price_desc":
                        carsQuery = carsQuery.OrderByDescending(car => car.Price);
                        break;

                    case "year_new":
                        carsQuery = carsQuery.OrderByDescending(car => car.Year);
                        break;

                    case "year_old":
                        carsQuery = carsQuery.OrderBy(car => car.Year);
                        break;
                }

            }
            //this is the same as before but now im calling it from the database and
            //using linq to filter and sort before it is executed and the data is retrieved
            
            var FilteredCars = carsQuery.ToList();
            //this just returns the list to the view which is picked up by the index cshtml page
            return View(FilteredCars);
            

        }
        //this action takes in an id from Details.cshtml and uses linq to find which id matches with the lists id and returns it
        // to make it a bit simpler look at the below
        //Click card ? ID goes to controller ? LINQ finds car ? returns Car object ? Details.cshtml prints it.
        public IActionResult Details(int id)
        {

            var carsQuery = _context.Cars.AsQueryable();

            var FilteredCars = carsQuery;
            //so i use var because the whole car is being picked up no just carid
            //this uses linq to find the first car in the list that matches the id passed in the url
            var selectedCar = carsQuery.FirstOrDefault(car => car.CarID == id);

            //if no car is found with that id return notfound simple
            if (selectedCar == null)
            {
                return NotFound();
            }
            //Returns the view of the selected car
            return View(selectedCar);
        
            
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
