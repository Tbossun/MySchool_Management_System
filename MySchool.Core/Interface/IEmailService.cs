using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
