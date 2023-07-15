using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;

namespace MySchool.Core.Interface
{
    public interface IAuthUser
    {
        Task<User> Login(LoginRequestDTO userRequest);
        Task<User> Register(User user);
    }
}