using MySchool.Core.Utils;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;
using MySchool.Models.UserActionParameters;

namespace MySchool.Core.Interface
{
    public interface IUserRepository
    {
        PagedList<User> GetAllUsers(int pageNo);
        Task<User> AddUser(User user);
        Task<bool> DeleteUser(string userId);
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmail(string email);
       /* IEnumerable<User> SearchUsers(UserActionParams userActionParams);*/
        Task<bool> UpdateUser(UpdateRequestDTO updateUser, string id);
        Task<bool> UpdateAvatarUrl(string Url, string Id);
    }
}