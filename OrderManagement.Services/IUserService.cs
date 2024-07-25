using OrderManagement.Core.Entities;
using OrderManagement.Core.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order_Management.Dto;
using Microsoft.AspNetCore.Identity;
namespace OrderManagement.Services
{
    public interface IUserService
    {
        Task<IdentityResult> RegisterUserAsync(RegisterDto registerUserDto);
        Task<string> AuthenticateUserAsync(LoginUserDto loginUserDto);
    }
}
