using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCBookingFinal_YARAB_.Models;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class CityController(ICityService cityService, IWebHostEnvironment _webhost, ICountryService countryService) : Controller
    {


		[Authorize(Roles = "ADMIN")]
		public ActionResult Index()
        {
            return View(cityService.GetAll());
        }


		//------------------------------------------------------------------------------------

		[Authorize(Roles = "ADMIN")]
		public ActionResult Details(int id)
        {
            return View(cityService.GetById(id));
        }




		//---------------------------------------------------------------------------------------




		[Authorize(Roles = "ADMIN")]
		public ActionResult Create()
        {
            ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create(CityViewModel vm)
        {

            if (ModelState.IsValid)
            {

                if (vm.Image == null)
                {
                    ModelState.AddModelError("Image", "Image cant be null");
                    ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");

                    return View(vm);
                }


                cityService.Create(vm);
                return RedirectToAction(nameof(Index));

            }
            ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");
            return View(vm);


        }




		//---------------------------------------------------------------------------------------




		[Authorize(Roles = "ADMIN")]
		public ActionResult Edit(int id)
        {
            ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");

            var cty = cityService.GetById(id);

            CityViewModel vm = new CityViewModel()
            {
                Id = id,
                Name = cty.Name,
                CountryId=cty.CountryId,
                
            };

            ViewBag.Img = cty.Image;
            if (cty == null)
            {
                return NotFound();
            }
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Edit(CityViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    cityService.Update(vm);
                }
                catch(Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");

                    return View(vm);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.countries = new SelectList(countryService.GetAll(), "Id", "Name");

            return View(vm);


        }




        //---------------------------------------------------------------------------------------




        [Authorize(Roles ="ADMIN")]
        public ActionResult Delete(int id)
        {
            return View(cityService.GetById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]

		public ActionResult ConfirmDelete(int id)
        {

                cityService.Delete(id);
                return RedirectToAction(nameof(Index));
            
  
        }
    }
}
