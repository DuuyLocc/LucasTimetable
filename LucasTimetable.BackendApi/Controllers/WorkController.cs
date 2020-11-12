using LucasTimetable.Application.Catalog.Works;
using LucasTimetable.ViewModel.Catalog.Works;
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

        // http://localhost:port/work
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _workSevice.GetAll();
            return Ok(result);
        }

        // http://localhost:port/work/paging-request
        [HttpGet("paging-request")]
        public async Task<IActionResult> Get([FromQuery] WorkPagingRequest request)
        {
            var result = await _workSevice.GetAllpaging(request);
            return Ok(result);
        }

        // getbyid
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int workId)
        {
            var result = await _workSevice.GetById(workId);
            if (result == null)
                return BadRequest("not found");
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]WorkCreateRequest request)
        {
            var workID = await _workSevice.Create(request);
            if (workID == 0) 
                return BadRequest();

            var work = await _workSevice.GetById(workID);
            return CreatedAtAction(nameof(GetById),new { id = workID },work);
        }

        [HttpPut]
        public async Task<IActionResult> Update(string id, [FromBody] WorkUpdateRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var affectedResult = await _workSevice.Update(id, request);
            if (affectedResult == 0)
                return BadRequest();
            return Ok();
        }
    }
}
