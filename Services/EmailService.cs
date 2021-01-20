using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace ImageAfricaProject.Services
{
    public class EmailService : IEmailService
    {
        // private readonly IEmailConfiguration _emailConfiguration;

        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        private async void SendEmail(MimeMessage message)
        {
            var SmtpServer = _config.GetSection("EmailConfig.SmtpServer").Value;
            var SmtpPort = Convert.ToInt32(_config.GetSection("EmailConfig.SmtpPort").Value);
            var SmtpUsername = _config.GetSection("EmailConfig.SmtpUsername").Value;
            var SmtpPassword = _config.GetSection("EmailConfig.SmtpPassword").Value;
            try
            {
                using (var smtp = new MailKit.Net.Smtp.SmtpClient())
                {
                    
                    await smtp.ConnectAsync(SmtpServer, SmtpPort);
                    var isSecure = smtp.IsSecure;
                    await smtp.AuthenticateAsync(SmtpUsername, SmtpPassword);
                    await smtp.SendAsync(message);
                    //await smtp.DisconnectAsync(true);
                }

                ;
               
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                
            }
           
        }

        private MimeMessage MessageBuilder(string to, string subject, string body)
        {
            var FromEmail = _config.GetSection("EmailConfig.FromEmail").Value; ;
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(FromEmail));
            message.To.Add(new MailboxAddress(to));
            message.Subject = subject;
            var builder = new BodyBuilder();
            builder.HtmlBody = body;
            message.Body = builder.ToMessageBody();
            return message;
        }

        public async Task Send(string to, string subject, string body)
        {
            var message = MessageBuilder(to, subject, body);
            SendEmail(message);
            // await SendWithMailGun(to, subject, body);
        }


        private async Task SendWithMailGun(string to, string subject, string body)
        {
            var ApiBaseUri = _config.GetSection("EmailConfig.ApiBaseUri").Value; ;
            var From = _config.GetSection("EmailConfig.From").Value; ;
            var ApiKey = _config.GetSection("EmailConfig.ApiKey").Value;
            var RequestUri = _config.GetSection("EmailConfig.RequestUri").Value;

            using (var client = new HttpClient
            {
                BaseAddress =
                new Uri(ApiBaseUri)
            })
            {
                //client.DefaultRequestHeaders.Authorization =
                //    new AuthenticationHeaderValue("Basic",
                //        Convert.ToBase64String(Encoding.ASCII.GetBytes(ApiKey)));
                client.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Basic",
                        ApiKey);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("from", From),
                    new KeyValuePair<string, string>("to", to),
                    new KeyValuePair<string, string>("subject", subject),
                    new KeyValuePair<string, string>("html", body)
                });

                await client.PostAsync(RequestUri,
                    content).ConfigureAwait(false);
            }
        }
    }
}