using Microsoft.AspNetCore.Identity;
using MySchool.Core.Interface;
using MySchool.Models.DTOs.REQUEST;
using MySchool.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchool.Core
{
    public class AuthUser : IAuthUser
    {
        public Task<User> Login(LoginRequestDTO userRequest)
        {
            throw new NotImplementedException();
        }

        public Task<User> Register(User user)
        {
            throw new NotImplementedException();
        }
    }
}
