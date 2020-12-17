﻿using LucasTimetable.Data.Entities;
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
                return new ApiErrorResult<string>("Tài khoản không tồn tại");
            }

            // login by username & password
            var result = await _signInManager.PasswordSignInAsync(user, request.PassWord, request.RememberMe, true);
            if (!result.Succeeded)
            {
                return new ApiErrorResult<string>("Password sai rồi!");
            }

            var roles = await _userManager.GetRolesAsync(user);
            //Only role == admin can be login
            if (!roles.Contains("admin"))
            {
                return new ApiErrorResult<string>("Vui lòng dùng tài khoản admin để đăng nhập!");
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
                return new ApiErrorResult<bool>("Tài khoản đã tồn tại hãy thử đăng ký lại!");
            }

            if (await _userManager.FindByEmailAsync(request.Email) != null)
            {
                return new ApiErrorResult<bool>("Email đã tồn tại hãy dùng email khác!");
            }

            string hoTen = request.Ho + " " + request.Ten;
            user = new AppUser()
            {
                NgaySinh = request.NgaySinh,
                Email    = request.Email,
                Ho       = request.Ho,
                Ten      = request.Ten,
                HoTen    = hoTen,
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

        public async Task<ApiResult<bool>> Update(Guid id, UserUpdateRequest request)
        {
            if (await _userManager.Users.AnyAsync(x => x.Email == request.Email && x.Id != id))
            {
                return new ApiErrorResult<bool>("Emai đã tồn tại");
            }
            var user = await _userManager.FindByIdAsync(id.ToString());
            user.NgaySinh = request.NgaySinh;
            user.Email    = request.Email;
            user.Ho       = request.Ho;
            user.Ten      = request.Ten;
            user.HoTen    = request.Ho + request.Ten;
            user.PhoneNumber = request.SoDienThoai;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return new ApiSuccessResult<bool>();
            }
            //return error list
            var errors = result.Errors;
            var errorMessage  = errors.Select(x => x.Description);
            string listErrors = string.Join(" ", errorMessage);
            return new ApiErrorResult<bool>(listErrors);
            //return new ApiErrorResult<bool>("Cập nhật không thành công");
        }

        public async Task<ApiResult<PagedResult<UserViewModel>>> GetUserPaging(GetUserPagingRequest request)
        {
            var query = _userManager.Users;
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.UserName.Contains(request.Keyword) || x.HoTen.Contains(request.Keyword)
                || x.Email.Contains(request.Keyword) || x.PhoneNumber.Contains(request.Keyword));
            }

            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new UserViewModel()
                {
                    Email       = x.Email,
                    SoDienThoai = x.PhoneNumber,
                    UserName    = x.UserName,
                    Ho  = x.Ho,
                    Ten = x.Ten,
                    Id  = x.Id
                }).ToListAsync();

            //4. Select and projection
            var pagedResult = new PagedResult<UserViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex    = request.PageIndex,
                PageSize     = request.PageSize,
                Items        = data
            };
            return new ApiSuccessResult<PagedResult<UserViewModel>>(pagedResult);
        }

        public async Task<ApiResult<UserViewModel>> GetById(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<UserViewModel>("User không tồn tại!");
            }
            var roles = await _userManager.GetRolesAsync(user);

            string HoTen = user.Ho + user.Ten;
            var userViewModel = new UserViewModel()
            {
                Id    = user.Id,
                Ho    = user.Ho,
                Ten   = user.Ten,
                HoTen = HoTen,
                Email = user.Email,
                SoDienThoai = user.PhoneNumber,
                NgaySinh    = user.NgaySinh,
                UserName    = user.UserName,
                Roles = roles
            };
            return new ApiSuccessResult<UserViewModel>(userViewModel);
        }

        public async Task<ApiResult<bool>> RoleAssign(Guid id, RoleAssignRequest request)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("Tài khoản không tồn tại!");
            }

            var removedRoles = request.Roles.Where(x => x.Selected == false).Select(x => x.Name).ToList();
            foreach (var roleName in removedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == true)
                {
                    await _userManager.RemoveFromRoleAsync(user, roleName);
                }
            }
            await _userManager.RemoveFromRolesAsync(user, removedRoles);

            var addedRoles = request.Roles.Where(x => x.Selected).Select(x => x.Name).ToList();
            foreach (var roleName in addedRoles)
            {
                if (await _userManager.IsInRoleAsync(user, roleName) == false)
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            return new ApiSuccessResult<bool>();
        }

        public async Task<ApiResult<bool>> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return new ApiErrorResult<bool>("User không tồn tại");
            }
            
            var result = await _userManager.DeleteAsync(user);
            // xuống tới đây là lỗi rồi stop luôn
            // khi ràng buộc khóa ngoại thì nên xài Cascade Delete để khi xóa ở bảng cha thì các bảng con có FK sẽ bị xóa theo
            if (result.Succeeded)
                return new ApiSuccessResult<bool>();

            return new ApiErrorResult<bool>("Xóa không thành công");
        }
    }
}
