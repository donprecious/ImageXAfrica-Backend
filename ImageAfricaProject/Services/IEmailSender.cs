using System.Threading.Tasks;

namespace ImageAfricaProject.Services
{
    public interface IEmailSender
    {
        Task SendConfirmationEmail(string email, string callbackUrl);    
        Task SendForgetPasswordEmail(string email, string callbackUrl);    
    }
}
