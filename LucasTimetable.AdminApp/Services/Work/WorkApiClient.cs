using LucasTimetable.ViewModel.Catalog.Works;
using LucasTimetable.ViewModel.Common;
using LucasTimetable.ViewModel.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LucasTimetable.AdminApp.Services.Work
{
    public class WorkApiClient : IWorkApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkApiClient(IHttpClientFactory httpClientFactory, IConfiguration configuration,
            IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<bool> Create(WorkCreateRequest request)
        {
            var sessions = _httpContextAccessor
                            .HttpContext
                            .Session
                            .GetString(SystemConstants.AppSettings.Token);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/works", httpContent);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int workId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client   = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);
            var response = await client.DeleteAsync($"/api/works/{workId}");
            var body = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public Task<List<WorkViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkViewModel> GetById(string workId)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration[SystemConstants.AppSettings.BaseAddress]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var response = await client.GetAsync(
                $"/api/works/{workId}"
                );

            var body     = await response.Content.ReadAsStringAsync();
            var work = JsonConvert.DeserializeObject<WorkViewModel>(body);

            return work;
        }

        public async Task<PagedResult<WorkViewModel>> GetWorkPaging(WorkPagingRequest request)
        {
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");
            var client   = _httpClientFactory.CreateClient();

            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            /*var response = await client.GetAsync(
                $"/api/Works/paging?pageIndex={request.PageIndex}" +
                $"&pageSize={request.PageSize}"+
                $"&keyword={request.KeyWork}");*/

            var response = await client.GetAsync($"/api/works/paging?pageIndex=" +
                $"{request.PageIndex}&pageSize={request.PageSize}&keyword={request.KeyWord}");

            var body  = await response.Content.ReadAsStringAsync();
            var works = JsonConvert.DeserializeObject<PagedResult<WorkViewModel>>(body);
            return works;
        }

        public async Task<bool> Update(int id, WorkUpdateRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(_configuration["BaseAddress"]);
            var sessions = _httpContextAccessor.HttpContext.Session.GetString("Token");

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sessions);

            var json        = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/works/{id}", httpContent);

            return response.IsSuccessStatusCode;
        }
    }
}
