using Microsoft.EntityFrameworkCore;
using CarSalesWeb.Models;
//this entire class is just a way to interact with the database,
//it has a DbSet of Cars which represents the Cars table in the database, 
//and it inherits from DbContext which is a class provided by Entity Framework Core
//that allows us to interact with the database using C# code instead of SQL queries.
namespace CarSalesWeb.Data
{




    public class CarDbContext : DbContext
    {
        //this just takes the config and lets the constructor take it
        public CarDbContext(DbContextOptions<CarDbContext> options)
            : base(options)
        {
        }
//this tells the database i have a table called cars i want to use it as objects
        public DbSet<Car> Cars { get; set; }
    }
}