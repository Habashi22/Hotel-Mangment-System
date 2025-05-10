using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBookingFinal_YARAB_.Data;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class CountriesController(ICountryService _countryService,IWebHostEnvironment _webhost) : Controller
    {


		// GET: Countries
		[Authorize(Roles = "ADMIN")]
		public IActionResult Index()
        {
            return View(_countryService.GetAll());
        }

		// GET: Countries/Details/5
		[Authorize(Roles = "ADMIN")]
		public IActionResult Details(int id)
        {
            var country = _countryService.GetById(id);
            if (country == null)
            {
                return NotFound();
            }

            return View(country);
        }

		// GET: Countries/Create
		[Authorize(Roles = "ADMIN")]
		public IActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public IActionResult Create(CountryViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.Image==null)
                {
                    ModelState.AddModelError("Image", "Image cant be null");
					return View(vm);
				}
                _countryService.Create(vm);
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

		// GET: Countries/Edit/5
		[Authorize(Roles = "ADMIN")]
		public IActionResult Edit(int id)
        {

            var country = _countryService.GetById(id);
            CountryViewModel vm = new()
            {
                Id = id,
                Name = country.Name,
            };
            ViewBag.DbImage = country.Image;
            if (country == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        // POST: Countries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public IActionResult Edit(CountryViewModel vm)
        {
           

            if (ModelState.IsValid)
            {
                try
                {
                    _countryService.Update(vm);
          
                }
                catch (Exception EX)
                {
                    ModelState.AddModelError("", EX.Message);
                   return View(vm);
				}
                return RedirectToAction(nameof(Index));
            }
            return View(vm);
        }

		// GET: Countries/Delete/5
		[Authorize(Roles = "ADMIN")]
		public IActionResult Delete(int id)
        {

            return View(_countryService.GetById(id));
        }

        // POST: Countries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public IActionResult DeleteConfirmed(int id)
        {
             _countryService.Delete(id);
           
            return RedirectToAction(nameof(Index));
        }

      
    }
}
