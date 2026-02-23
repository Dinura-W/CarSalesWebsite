using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarSalesWeb.Data;
using CarSalesWeb.Models;

namespace CarSalesWeb.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarDbContext _context;

        public CarsController(CarDbContext context)
        {
            _context = context;
        }

      

        // GET: Cars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public async Task<IActionResult> Create([Bind("CarID,Manufacturer,Model,Year,Price,Odometer,Category,Image,Description")] Car car, IFormFile CarImage)
        {

            //this is to upload images
            if (ModelState.IsValid)
            {
                //checks if empty
                if (CarImage != null && CarImage.Length > 0)
                {
                    //gets the file name
                    var fileName = Path.GetFileName(CarImage.FileName);
                    //saves the file path to carimages
                    var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Carimages", fileName);
                    //Open a file stream at that save path ready to write to it
                    using (var stream = new FileStream(savePath, FileMode.Create))
                    {
                        //saves the file name
                        await CarImage.CopyToAsync(stream);
                    }
                    // stores this filename into the database
                    car.Image = fileName;
                }
                //data is saved and user sent back to index page
                _context.Add(car);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }


            return View(car);


        }



        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CarID,Manufacturer,Model,Year,Price,Odometer,Category,Image,Description")] Car car)
        {
            if (id != car.CarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(car);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.CarID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Cars
                .FirstOrDefaultAsync(m => m.CarID == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                _context.Cars.Remove(car);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarExists(int id)
        {
            return _context.Cars.Any(e => e.CarID == id);
        }
    }
}
