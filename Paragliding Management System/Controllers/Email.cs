using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Paragliding_Management_System.Controllers
{
    public class Email
    {
        public void SendEmail(string subject, string message, string address)
        {
            using (MailMessage mm = new MailMessage("librarymgmtsys@gmail.com", address))
            {
                mm.Subject = subject;
                mm.Body = message;
                mm.IsBodyHtml = false;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                // Update network credential
                NetworkCredential networkCred = new NetworkCredential("email id", "password");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = networkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }

        }
    }
}
