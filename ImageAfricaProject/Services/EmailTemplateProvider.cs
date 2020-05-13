using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace ImageAfricaProject.Services
{
    public class EmailTemplateProvider : IEmailTemplateProvider
    {
        private IWebHostEnvironment _hostingEnvironment;

        public EmailTemplateProvider(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public string GetEmailTemplate()
        {

            var path = _hostingEnvironment.ContentRootPath +Path.DirectorySeparatorChar.ToString();
            string FilePath = path + 
                              $"Templates{Path.DirectorySeparatorChar.ToString()}" +
                              $"EmailNotificationTemplate.html";
            StreamReader str = new StreamReader(FilePath);
            string MailText  = str.ReadToEnd();
            str.Close();
            return MailText;
        }

       
    }
}
