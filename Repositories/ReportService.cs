
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MVCBookingFinal_YARAB_.Repositories
{
    public class ReportService(ApplicationDbContext context) : IReportService
    {


        public List<Report> GetAllReports()
        {
            return context.Reports.Include(u=>u.User).Include(h=>h.Hotel).Where(r=>!r.Hotel.isDeleted).ToList();
        }

        public Report GetReportByid(int id)
        {
            return context.Reports.Include(u => u.User).Include(h => h.Hotel). SingleOrDefault(r=> r.Id == id);
        }



        public void CreateReport(ReportViewModel vm)
        {
            var report= new Report()
            {
                 Complaint=vm.Complaint,
                  HotelId=vm.HotelId,
                   UserId=vm.UserId,
                    ReviewDate=DateTime.Now,
            };
            context.Reports.Add(report);
            context.SaveChanges();
        }


      

        public void UpdateReport(ReportViewModel vm)
        {
            
            var updatedReport= context.Reports.FirstOrDefault(R=>R.Id==vm.Id);
            if (updatedReport != null) 
            {
                updatedReport.Complaint = vm.Complaint;
                updatedReport.HotelId=vm.HotelId;
                updatedReport.UserId=vm.UserId;
                updatedReport.ReviewDate=DateTime.Now;
            
            }
            context.SaveChanges();



        }
        public void DeleteReport(int id)
        {
           var item= context.Reports.FirstOrDefault(r=>r.Id==id);
            context.Reports.Remove(item);
            context.SaveChanges();

        }
    }
}
