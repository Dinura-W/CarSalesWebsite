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

            /*
            Car car1 = new Car
            {

                CarID = 1,
                Manufacturer = "Nissan",
                Model = "370z",
                Year = 2010,
                Price = 20000,
                Odometer = 100000,
                Category = "Sports",
                Image = "370z.jpg"
            };

            Car car2 = new Car
            {

                CarID = 2,
                Manufacturer = "Mitsubishi",
                Model = "Evolution V",
                Year = 1999,
                Price = 60000,
                Odometer = 98000,
                Category = "Sports Rally",
                Image = "evo5.jpg"
            };

            Car car3 = new Car
            {

                CarID = 3,
                Manufacturer = "Subaru",
                Model = "Impreza WRX STI",
                Year = 2001,
                Price = 80000,
                Odometer = 50000,
                Category = "Sports Rally",
                Image = "wrx.jpg"
            };

            //from here onwards i asked chatgpt to add dummy data
            
            Car car4 = new Car
            {
                CarID = 4,
                Manufacturer = "Toyota",
                Model = "Supra MK4",
                Year = 1998,
                Price = 150000,
                Odometer = 70000,
                Category = "Sports",
                Image = "supra_mk4.jpg"
            };

            Car car5 = new Car
            {
                CarID = 5,
                Manufacturer = "Mazda",
                Model = "RX-7 FD",
                Year = 1997,
                Price = 120000,
                Odometer = 85000,
                Category = "Sports",
                Image = "rx7_fd.jpg"
            };

            Car car6 = new Car
            {
                CarID = 6,
                Manufacturer = "Nissan",
                Model = "Skyline GT-R R34",
                Year = 1999,
                Price = 180000,
                Odometer = 60000,
                Category = "Sports",
                Image = "r34.jpg"
            };

            Car car7 = new Car
            {
                CarID = 7,
                Manufacturer = "Honda",
                Model = "NSX",
                Year = 1995,
                Price = 140000,
                Odometer = 90000,
                Category = "Sports",
                Image = "nsx.jpg"
            };

            Car car8 = new Car
            {
                CarID = 8,
                Manufacturer = "Nissan",
                Model = "Silvia S15",
                Year = 2001,
                Price = 55000,
                Odometer = 120000,
                Category = "Sports Drift",
                Image = "s15.jpg"
            };

            Car car9 = new Car
            {
                CarID = 9,
                Manufacturer = "Toyota",
                Model = "AE86 Trueno",
                Year = 1986,
                Price = 65000,
                Odometer = 140000,
                Category = "Classic Drift",
                Image = "ae86.jpg"
            };

            Car car10 = new Car
            {
                CarID = 10,
                Manufacturer = "Mitsubishi",
                Model = "3000GT VR-4",
                Year = 1995,
                Price = 45000,
                Odometer = 110000,
                Category = "Sports",
                Image = "3000gt.jpg"
            };

            Car car11 = new Car
            {
                CarID = 11,
                Manufacturer = "Subaru",
                Model = "Impreza 22B STI",
                Year = 1998,
                Price = 300000,
                Odometer = 40000,
                Category = "Sports Rally",
                Image = "22b.jpg"
            };


      





                //this is me creating a list to hold the car objects
                var Carlist = new List<Car> { };
            Carlist.Add(car1);
            Carlist.Add(car2);
            Carlist.Add(car3);
            Carlist.Add(car4);
            Carlist.Add(car5);
            Carlist.Add(car6);
            Carlist.Add(car7);
            Carlist.Add(car8);
            Carlist.Add(car9);
            Carlist.Add(car10);
            Carlist.Add(car11);


            var FilteredCars = Carlist;
            //this checks what cars contain whats in the search
            if (!string.IsNullOrEmpty(search))
            {
                FilteredCars = Carlist.Where(car => 
                 car.Manufacturer.Contains(search, StringComparison.OrdinalIgnoreCase) ||           
                 car.Model.Contains(search, StringComparison.OrdinalIgnoreCase) || 
                 car.Category.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            }
            //so this checks the url to see what was clicked on from index.cshtml
            //the if checks if it is not empty and the switch checks which value was selected
            //the selected value is picked and the code decides to either order by asc or desc
            if (!string.IsNullOrEmpty(sortOrder))
            {
                switch (sortOrder)
                {
                    case "price_asc":
                        FilteredCars = FilteredCars.OrderBy(car => car.Price).ToList();
                        break;

                    case "price_desc":
                        FilteredCars = FilteredCars.OrderByDescending(car => car.Price).ToList();
                        break;

                    case "year_new":
                        FilteredCars = FilteredCars.OrderByDescending(car => car.Year).ToList();
                        break;

                    case "year_old":
                        FilteredCars = FilteredCars.OrderBy(car => car.Year).ToList();
                        break;
                }

            }

            ViewData["CurrentSearch"] = search; // store the search term for the view so the search stays when sortby is selected

            //this returns the list to the view which is picked up by the index cshtml page
            return View(FilteredCars);

        

        */

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
