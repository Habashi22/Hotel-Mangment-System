namespace MVCBookingFinal_YARAB_.IRepositories
{
    public interface IReportService
    {
        public List<Report> GetAllReports();
        public Report GetReportByid(int id);
        public void CreateReport(ReportViewModel vm);
        public void UpdateReport(ReportViewModel vm);
        public void DeleteReport(int id);

    }
}
