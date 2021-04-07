using System.Threading.Tasks;

namespace BlazorServerBlog.Services
{

    public interface IMailService
    {
        Task SendEmail(string to, string subject, string body);
    }
}