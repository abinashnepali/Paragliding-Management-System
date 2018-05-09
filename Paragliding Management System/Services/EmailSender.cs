using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System;

namespace Paragliding_Management_System.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("paraglidingmgmt@gmail.com", "paragliding1@3");
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("paraglidingmgmt@gmail.com");
                mailMessage.To.Add(email);
                mailMessage.Body = message;
                mailMessage.Subject = subject;
                client.Send(mailMessage);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
