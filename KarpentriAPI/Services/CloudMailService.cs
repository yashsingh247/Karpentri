namespace KarpentriAPI.Services
{
    public class CloudMailService : IMailService 
    {
        private string _mailTo = "admina@demo.com";
        private string _mailFrom = "sender@demo.com";

        public void Send(string subject, string body)
        {
            Console.WriteLine($"CloudMail from {_mailFrom} to {_mailTo}," + $"with {nameof(LocalMailService)}");
            Console.WriteLine($"Subject : {subject}");
            Console.WriteLine($"Body : {body}");
        }
    }
}
