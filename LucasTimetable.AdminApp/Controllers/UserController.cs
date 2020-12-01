﻿using LucasTimetable.AdminApp.Services;
using LucasTimetable.ViewModel.System.Users;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LucasTimetable.AdminApp.Controllers
{
    //[Authorize]
    public class UserController : BaseController
    {
         private readonly IUserApiClient _userApiClient;
         private readonly IConfiguration _configuration;

         public UserController(IUserApiClient userApiClient, IConfiguration configuration)
         {
             _userApiClient = userApiClient;
             _configuration = configuration;
         }

         public async Task<IActionResult> Index(string keyword, int pageIndex =1, int pageZise = 10)
         {
             //var sessions = HttpContext.Session.GetString("Token");
             var request  = new GetUserPagingRequest()
             {
                 //BearerToken = sessions,
                 Keyword     = keyword,
                 PageIndex   = pageIndex,
                 PageSize    = pageZise
             };
             var data = await _userApiClient.GetUsersPaging(request);

             ViewBag.Keyword = keyword;

             if (TempData["result"] != null)
             {
                 ViewBag.SuccessMessage = TempData["result"];
             }

             return View(data.ResultObj);
         }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _userApiClient.RegisterUser(request);
            if (result.IsSuccessed)
            {
                TempData["result"] = "Success";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", result.Message);
            return View(request);
        }


    }
}
