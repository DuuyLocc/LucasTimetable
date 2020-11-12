using LucasTimetable.ViewModel.Catalog.Works;
using System;
using System.Collections.Generic;
using System.Text;
using LucasTimetable.ViewModel.Common;
using System.Threading.Tasks;

namespace LucasTimetable.Application.Catalog.Works
{
    public interface IWorkSevice
    {
        Task<int> Create(WorkCreateRequest request);

        Task<int> Update(string id, WorkUpdateRequest request);

        Task<int> Delete(string workId);

        Task<WorkViewModel> GetById(int workId);

        Task<List<WorkViewModel>> GetAll();

        Task<PagedResult<WorkViewModel>> GetAllpaging(WorkPagingRequest request);
    }
}
