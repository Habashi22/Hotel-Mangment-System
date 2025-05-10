namespace MVCBookingFinal_YARAB_.Models
{
    public class Email2
    {       
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        IList<IFormFile>? attachemets { get; set; }
    }
}
