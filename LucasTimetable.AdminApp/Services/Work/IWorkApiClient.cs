using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LucasTimetable.AdminApp.Services.Work
{
    public interface IWorkApiClient
    {
        Task<ApiResult<PagedResult<WorkViewModel>>> GetWorkPaging(WorkPagingRequest request);

        Task<ApiResult<bool>> UpdateWork(Guid id, UserUpdateRequest request);

        Task<ApiResult<UserViewModel>> GetById(Guid id);

        Task<ApiResult<bool>> DeleteWork(Guid id);
    }
}
