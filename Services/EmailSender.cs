using System.Text;
using System.Threading.Tasks;

namespace ImageAfricaProject.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailTemplateProvider _emailTemplateProvider;
        private readonly IEmailService _emailService;

        public EmailSender(IEmailTemplateProvider emailTemplateProvider, IEmailService emailService)
        {
            _emailTemplateProvider = emailTemplateProvider;
            _emailService = emailService;
        }

        public async Task SendConfirmationEmail(string email, string callbackUrl)
        {
            var mailTemp = new StringBuilder(_emailTemplateProvider.GetEmailTemplate());
            mailTemp.Replace("{header}", "Verify your email");
            mailTemp.Replace("{body}", "To complete the sign up process, please click the button below to verify your email");
            mailTemp.Replace("{url}", callbackUrl);
            mailTemp.Replace("{btn-text}", "confirm email");

            await _emailService.Send(email, "Confirm My Account", mailTemp.ToString());
        }

        public async Task SendForgetPasswordEmail(string email, string callbackUrl)
        {
            var mailTemp = new StringBuilder(_emailTemplateProvider.GetEmailTemplate());
            mailTemp.Replace("{header}", "Reset your password");
            mailTemp.Replace("{body}", "someone, possibly you requested for a password reset link. if you did not request for any, please ignore this email");
            mailTemp.Replace("{url}", callbackUrl);
            mailTemp.Replace("{btn-text}", "reset password");

            await _emailService.Send(email, "Reset my password", mailTemp.ToString());
        }
    }
}
