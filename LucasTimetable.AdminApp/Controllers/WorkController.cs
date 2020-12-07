using LucasTimetable.AdminApp.Services;
using LucasTimetable.AdminApp.Services.Work;
using LucasTimetable.ViewModel.Catalog.Works;
using LucasTimetable.ViewModel.Common;
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
    public class WorkController : BaseController
    {
        private readonly IWorkApiClient _workApiClient;
        private readonly IConfiguration _configuration;


        public WorkController(IWorkApiClient workApiClient, IConfiguration configuration)
        {
            _workApiClient = workApiClient;
            _configuration = configuration;
        }

        public async Task<IActionResult> Index(string keyword, int pageIndex = 1, int pageZise = 5)
        {
            
            var request = new WorkPagingRequest()
            {
                KeyWord   = keyword,
                PageIndex = pageIndex,
                PageSize  = pageZise
            };
            var data = await _workApiClient.GetWorkPaging(request);
            ViewBag.keyword = keyword;

            if (TempData["result"] != null)
            {
                ViewBag.SuccessMessage = TempData["result"];
            }
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] WorkCreateRequest request)
        {
            if (!ModelState.IsValid)
                return View(request);

            var result = await _workApiClient.Create(request);
            if (result)
            {
                TempData["result"] = "Thêm mới công việc thành công!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Thêm công việc thất bại!");
            return View(request);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var result = await _workApiClient.GetById(id);
            if (result != null)
            {
                var updateRequest = new WorkUpdateRequest()
                {
                    Name        = result.Name,
                    Description = result.Description,
                    Status      = result.Status,
                    Priority    = result.Priority,
                    Deadline    = result.Deadline
                };
                return View(updateRequest);
            }
            return RedirectToAction("Error", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, WorkUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            var result = await _workApiClient.Update(id, request);
            if (result)
            {
                TempData["result"] = "Cập nhật công việc thành công!";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Cập nhật công việc không thành công!");
            return View(request);
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            return View(new WorkDeleteRequest()
            {
                Id = Id
            });
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WorkDeleteRequest request)
        {
            if (!ModelState.IsValid)
                return View();
            var result = await _workApiClient.Delete(request.Id);
            if (result)
            {
                TempData["result"] = "Xóa công việc thành công!";
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Xóa công việc không thành công!");
            return View(request);
        }
    }
}
