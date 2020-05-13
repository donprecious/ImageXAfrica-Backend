using System.Threading.Tasks;

namespace ImageAfricaProject.Services
{
    public interface IEmailService
    {
        Task Send(string to, string subject, string body);
    }
}