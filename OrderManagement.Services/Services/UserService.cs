using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Order_Management.Dto;
using OrderManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Services.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<User> userManager, IConfiguration configuration) 
        {
            _userManager = userManager;
            _configuration = configuration;
        }


        public async Task<string> AuthenticateUserAsync(LoginUserDto loginUserDto)
        {
            var user =  await _userManager.FindByEmailAsync(loginUserDto.Email);
            if(user == null || ! await _userManager.CheckPasswordAsync(user, loginUserDto.Password))
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, ClaimTypes.Role),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"]

            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<IdentityResult> RegisterUserAsync(RegisterDto registerUserDto)
        {
            var user = new User
            {
                Username = registerUserDto.UserName
            };
            var result = await _userManager.CreateAsync(user , registerUserDto.Password);
           if(result.Succeeded && !string.IsNullOrWhiteSpace(user.Role))
            {
            await _userManager.AddToRoleAsync(user, user.Role);

            }
            return result;
        }
    }
}
