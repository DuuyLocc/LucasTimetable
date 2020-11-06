using LucasTimetable.Data.EF;
using LucasTimetable.Data.Entities;
using LucasTimetable.ViewModel.Catalog.Works;
using LucasTimetable.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LucasTimetable.Application.Catalog.Works
{
    public class WorkSevice : IWorkSevice
    {
        // bien noi bo de don gia tri tu Timetable_DBcontext
        private readonly Timetable_DBcontext _context;
        // contructor
        public WorkSevice(Timetable_DBcontext context)
        {
            _context = context;
        }

        public async Task<int> Create(WorkCreateRequest request)
        {
            var work = new Work()
            {
                Name = request.Name,
                Description = request.Description,
                Status = request.Status,
                Priority = request.Priority,
                Deadline = request.Deadline
            };
            _context.Works.Add(work);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int workId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<WorkViewModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedResult<WorkViewModel>> GetAllpaging(string keywork, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<int> Update(WorkUpdateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
