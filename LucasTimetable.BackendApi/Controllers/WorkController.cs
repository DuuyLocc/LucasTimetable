using LucasTimetable.Application.Catalog.Works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucasTimetable.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private IWorkSevice _workSevice;
        public WorkController(IWorkSevice workSevice)
        {
            _workSevice = workSevice;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _workSevice.GetAll();
            return Ok(result);
        }
    }
}
