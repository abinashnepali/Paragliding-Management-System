using System.Threading.Tasks;

namespace Paragliding_Management_System.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
