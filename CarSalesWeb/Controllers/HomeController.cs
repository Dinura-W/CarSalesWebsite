using System.Diagnostics;
using CarSalesWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSalesWeb.Controllers
{
    public class HomeController : Controller
    {

        //So this i where i created the objects for the cars to be displayed on the index page.

        //when the search is used in index the it will replace string search with the search term and can be used to filter the list of cars shown
        public IActionResult Index(string search)
        {

            

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

            if (!string.IsNullOrEmpty(search))
            {
                FilteredCars = Carlist.Where(car => 
                 car.Manufacturer.Contains(search, StringComparison.OrdinalIgnoreCase) ||           
                 car.Model.Contains(search, StringComparison.OrdinalIgnoreCase) || 
                 car.Category.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            }


            //this returns the list to the view which is picked up by the index cshtml page
            return View(FilteredCars);

        

        

        }
        //this action takes in an id from Details.cshtml and uses linq to find which id matches with the lists id and returns it
        // to make it a bit simpler look at the below
        //Click card ? ID goes to controller ? LINQ finds car ? returns Car object ? Details.cshtml prints it.
        public IActionResult Details(int id)
        {
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
            //so i use var because the whole car is being picked up no just carid
            //this uses linq to find the first car in the list that matches the id passed in the url
            var selectedCar = Carlist.FirstOrDefault(car => car.CarID == id);

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
