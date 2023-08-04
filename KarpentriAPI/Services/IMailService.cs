namespace KarpentriAPI.Services
{
    public interface IMailService
    {
         void Send(string subject, string body);
    }
}
