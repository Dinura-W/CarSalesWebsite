using System;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace CarSalesWeb.Models
{
    public class carproperties
    {





    }
    //So pretty much i just created a class with attributes that have constructors.
    //The actual objects are created in HomeController.cs so check that out.
    public class Car
    {
        public int CarID { get; set; }
        public string Manufacturer { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int Year { get; set; }
        public int Price { get; set; }
        public int Odometer { get; set; }
        public string Category { get; set; } = null!;
        public string Image { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
