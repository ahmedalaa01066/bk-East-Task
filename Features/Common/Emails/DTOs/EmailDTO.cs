namespace EasyTask.Features.Common.Emails.DTOs
{
    public class EmailDTO
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public List<string> EmailAdresses { get; set; }

    }

}
