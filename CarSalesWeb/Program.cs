using CarSalesWeb.Data;
using CarSalesWeb.Models;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

//bunch of code to connect to the database, using the connection string from appsettings.json and using the CarDbContext class to interact
//Whenever someone asks for a CarDbContext, here’s how to give it to them
builder.Services.AddDbContext<CarDbContext>(options =>
//this tells ef core that we are using mysql
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();




//“I need to borrow a database session, and I don’t want it hanging around after I’m done.”
using var scope = app.Services.CreateScope();

//Give me an instance of CarDbContext. If it doesn’t exist, throw an error.
//context is the actual connection to the database
var context = scope.ServiceProvider.GetRequiredService<CarDbContext>();


//this is just a failsafe to make sure the database is created if it doesn’t exist
if (!context.Cars.Any())
{
    // STEP: create a few car objects
    var car1 = new Car {Manufacturer = "Nissan", Model = "370z", Year = 2010, Price = 20000, Odometer = 100000, Category = "Sports", Image = "370z.jpg", Description = "TEST CASE1" };
    var car2 = new Car {Manufacturer = "Mitsubishi", Model = "Evo V", Year = 1999, Price = 60000, Odometer = 98000, Category = "Sports Rally", Image = "evo5.jpg", Description = "TEST CASE2" };


    context.Cars.Add(car1);
    context.Cars.Add(car2);

    try
    {
        context.SaveChanges();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine(ex.InnerException?.Message);
    }


}





// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
