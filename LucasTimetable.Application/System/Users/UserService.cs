using LucasTimetable.Data.Entities;
using LucasTimetable.ViewModel.Common;
using LucasTimetable.ViewModel.Exceptions;
using LucasTimetable.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LucasTimetable.Application.System.Users
{
    public class UserService : IUserService
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;
        private RoleManager<AppRole> _roleManager;
        private readonly IConfiguration _config;

        public UserService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager
            , IConfiguration config)
        {
            _userManager   = userManager;
            _signInManager = signInManager;
            _roleManager   = roleManager;
            _config        = config;
        }

        public Task<bool> Register(RegisterRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            // find username
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                //return null;
                return new ApiErrorResult<string>("account not exist");
            }

            // login by username & password
            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded)
            {
                //return null;
                return new ApiErrorResult<string>("wrong password");
            }

            var roles = await _userManager.GetRolesAsync(user);
            //Only role == admin can be login
            if (!roles.Contains("admin"))
            {
                return new ApiErrorResult<string>("The account is not allowed to login");
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.GivenName,user.HoTen),
                //truyền list roles vào, ngăn cách bởi dấu ;
                new Claim(ClaimTypes.Role, string.Join(";",roles)),
                new Claim(ClaimTypes.Name, request.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}
