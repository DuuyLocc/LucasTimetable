using LucasTimetable.ViewModel.Catalog.Works;
using LucasTimetable.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucasTimetable.AdminApp.Services.Work
{
    public interface IWorkApiClient
    {
        Task<PagedResult<WorkViewModel>> GetWorkPaging(WorkPagingRequest request);

        Task<bool> Create(WorkCreateRequest request);

        Task<bool> Update(int id, WorkUpdateRequest request);

        Task<bool> Delete(int workId);

        Task<WorkViewModel> GetById(string workId);

        Task<List<WorkViewModel>> GetAll();

    }
}
