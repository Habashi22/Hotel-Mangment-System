using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;

namespace MVCBookingFinal_YARAB_.Controllers
{
    public class ReportController(IReportService reportService,ApplicationDbContext context) : Controller
    {
		// GET: ReportController
		[Authorize(Roles = "ADMIN")]
		public ActionResult Index()
        {
            var reports = reportService.GetAllReports();
            return View(reports);
        }
		[Authorize(Roles = "ADMIN")]
		// GET: ReportController/Details/5
		public ActionResult Details(int id)
        {
            var userreport = reportService.GetReportByid(id);
            return View(userreport);
        }

		// GET: ReportController/Create
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create()
        {
			ViewBag.HotelId = new SelectList(context.Hotels.Where(h => !h.isDeleted), "id", "Name");


			return View();
        }

        // POST: ReportController/Create
        [HttpPost]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Create(ReportViewModel vm)
        {
			ViewBag.HotelId = new SelectList(context.Hotels.Where(h => !h.isDeleted), "id", "Name");
			if (ModelState.IsValid)
            {
                vm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
				reportService.CreateReport(vm);
                return RedirectToAction(nameof(Index));

            }
            return View(vm);
        }

        // GET: ReportController/Edit/5
        public ActionResult Edit(int id)
        {
			ViewBag.HotelId = new SelectList(context.Hotels.Where(h => !h.isDeleted), "id", "Name");
			var report = reportService.GetReportByid(id);
            ReportViewModel vm = new ReportViewModel()
            {
                Id = id,
				UserId=User.FindFirstValue(ClaimTypes.NameIdentifier),
				Complaint = report.Complaint,
                HotelId = report.HotelId,

            };
            return View(vm);
        }

        // POST: ReportController/Edit/5
        [HttpPost]
		[Authorize(Roles = "ADMIN")]
		public ActionResult Edit(ReportViewModel vm)
        {
			ViewBag.HotelId = new SelectList(context.Hotels.Where(h => !h.isDeleted), "id", "Name");
			if (ModelState.IsValid)
            {
                vm.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

					reportService.UpdateReport(vm);
                    return RedirectToAction(nameof(Index));
                
            }
                    return View(vm);

        }



		[Authorize(Roles = "ADMIN")]
		public ActionResult Delete(int id)
        {
            var report = reportService.GetReportByid(id);
            if (report == null)
            {
                return NotFound();  
            }

            return View(report);
        }


       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = "ADMIN")]
		public ActionResult DeleteConfirmed(int id)
        {
            var report = reportService.GetReportByid(id);
            if (report == null)
            {
                return NotFound();  
            }

         
            reportService.DeleteReport(id);

            
            return RedirectToAction(nameof(Index));
        }
        //comment

    }

  
}

