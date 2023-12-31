﻿using Microsoft.AspNetCore.Identity;
using MySchool.Core.Interface;
using MySchool.Core.Utils;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;
using MySchool.Models.UserActionParameters;

namespace MySchool.Core
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<User> GetUserById(string userId) => await _userManager.FindByIdAsync(userId);

        public async Task<User> GetUserByEmail(string userEmail) => await _userManager.FindByEmailAsync(userEmail);

        public async Task<User> AddUser(User user)
        {
            user.UserName = string.IsNullOrWhiteSpace(user.UserName) ? user.Email : user.UserName;
            user.CreatedAt = DateTime.Now;

            IdentityResult result = await _userManager.CreateAsync(user, user.Password);
            if (result.Succeeded)
            {
                return user;
            }

            string errors = string.Empty;
            foreach (var error in result.Errors)
            {
                errors += error.Description + Environment.NewLine;
            }
            throw new MissingFieldException(errors);
        }


        /*public IEnumerable<User> SearchUsers(UserActionParams userActionParams)
        {
            var collection = _userManager.Users;

            // Gets users from a specific state (Filtering)
            if (!string.IsNullOrWhiteSpace(userActionParams.StateName))
            {
                collection = collection.Where(user => user.State == userActionParams.StateName);
            }

            // Gets users whose First Name, Last Name or City matches a specific search word
            if (!string.IsNullOrWhiteSpace(userActionParams.SearchWord))
            {
                string searchWord = userActionParams.SearchWord;
                collection = collection.Where(user => user.UserName.Contains(searchWord)
                                            || user.FirstName.Contains(searchWord)
                                            || user.LastName.Contains(searchWord));
            }
            return collection.Skip(10 * (userActionParams.Page - 1))
                             .Take(10).ToList();
        }*/


        public PagedList<User> GetAllUsers(int pageNo)
        {
            var collection = _userManager.Users;
            return PagedList<User>.Create(collection, pageNo);
        }


        public async Task<bool> DeleteUser(string userId)
        {
            User user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return true;
                return false;
            }
            throw new ArgumentException("User does not exist");
        }


        public async Task<bool> UpdateUser(UpdateRequestDTO updateUser, string id)
        {
            User user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
               // user.FirstName = string.IsNullOrWhiteSpace(updateUser.FirstName) ? user.FirstName : updateUser.FirstName;
              //  user.LastName = string.IsNullOrWhiteSpace(updateUser.LastName) ? user.LastName : updateUser.LastName;
                user.PhoneNumber = string.IsNullOrWhiteSpace(updateUser.PhoneNumber) ? user.PhoneNumber : updateUser.PhoneNumber;
               // user.StreetAddress = string.IsNullOrWhiteSpace(updateUser.StreetAddress) ? user.StreetAddress : updateUser.StreetAddress;
               // user.City = string.IsNullOrWhiteSpace(updateUser.City) ? user.City : updateUser.City;
              //  user.State = string.IsNullOrWhiteSpace(updateUser.State) ? user.State : updateUser.State;
                user.Email = string.IsNullOrWhiteSpace(updateUser.Email) ? user.Email : updateUser.Email;
                user.Password = string.IsNullOrWhiteSpace(updateUser.Password) ? user.Password : updateUser.Password;
                user.UserName = string.IsNullOrWhiteSpace(updateUser.UserName) ? user.UserName : updateUser.UserName;

                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return true;
                return false;
            }
            throw new ArgumentException("User does not exist");
        }


        public async Task<bool> UpdateAvatarUrl(string Url, string Id)
        {
            User user = await _userManager.FindByIdAsync(Id);
            user.AvatarUrl = Url;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
                return true;
            return false;
        }
    }
}
