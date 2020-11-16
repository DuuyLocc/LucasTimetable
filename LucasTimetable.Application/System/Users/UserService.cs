using LucasTimetable.Data.Entities;
using LucasTimetable.ViewModel.Common;
using LucasTimetable.ViewModel.System.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _config = config;
        }

        public async Task<ApiResult<string>> Authencate(LoginRequest request)
        {
            // find username
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return new ApiErrorResult<string>("account not exist");
            }

            // login by username & password
            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded)
            {
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

            var key   = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Tokens:Issuer"],
                _config["Tokens:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: creds);

            return new ApiSuccessResult<string>(new JwtSecurityTokenHandler().WriteToken(token));
        }

        public async Task<ApiResult<bool>> Register(RegisterRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user != null)
            {
                return new ApiErrorResult<bool>("account has exist");
            }

            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("email has exist");
            }

            string hoTen = request.Ho + " " + request.Ten;
            user = new AppUser()
            {
                NgaySinh = request.NgaySinh,
                Email = request.Email,
                Ho = request.Ho,
                Ten = request.Ten,
                HoTen = hoTen,
                UserName = request.UserName,
                PhoneNumber = request.SoDienThoai
            };

            var result = await _userManager.CreateAsync(user, request.Password);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }

            //return error list if register request conflict with rule of Idenity
            var errors = result.Errors;
            var errorMessage = errors.Select(x => x.Description);
            string listErrors = string.Join(" ", errorMessage);
            return new ApiErrorResult<bool>(listErrors);
        }
    }
}
