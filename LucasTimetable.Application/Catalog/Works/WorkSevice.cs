using LucasTimetable.Data.EF;
using LucasTimetable.Data.Entities;
using LucasTimetable.ViewModel.Catalog.Works;
using LucasTimetable.ViewModel.Common;
using LucasTimetable.ViewModel.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            await _context.SaveChangesAsync();
            return work.Id;
        }

        public async Task<int> Delete(int workId)
        {
            var work = await _context.Works.FindAsync(workId);
            if (work == null)
            {
                throw new LucasTimetable_Exceptions($"Không tìm thấy công việc có Id là {workId} để xóa!");
            }

            _context.Works.Remove(work);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<WorkViewModel>> GetAll()
        {
            var query = from w
                        in _context.Works
                        select new { w };

            var data = await query.Select(x => new WorkViewModel()
                {
                    Id = x.w.Id,
                    Name = x.w.Name,
                    Description = x.w.Description,
                    Status = (Data.Enums.Status)x.w.Status,
                    Priority = (Data.Enums.Priority)x.w.Priority,
                    Deadline = x.w.Deadline
                }).ToListAsync();
            return data;
        }

/*        public async Task<PagedResult<WorkViewModel>> GetAllpaging(string keywork, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }*/

        public async Task<PagedResult<WorkViewModel>> GetAllpaging(WorkPagingRequest request)
        {
            var query = from w 
                        in _context.Works 
                        select new { w };

            if (!string.IsNullOrEmpty(request.KeyWork))
            {
                query = query.Where(x => x.w.Name.Contains(request.KeyWork) || x.w.Description.Contains(request.KeyWork));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new WorkViewModel()
                {
                    Id = x.w.Id,
                    Name = x.w.Name,
                    Description = x.w.Description,
                    Status = (Data.Enums.Status)x.w.Status,
                    Priority = (Data.Enums.Priority)x.w.Priority,
                    Deadline = x.w.Deadline
                }).ToListAsync();

            var pagedResult = new PagedResult<WorkViewModel>()
            {
                TotalRecord = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<WorkViewModel> GetById(int workId)
        {
            var work = await _context.Works.FindAsync(workId);
            if (work == null)
                throw new LucasTimetable_Exceptions($"không tìm thấy công việc có Id là {workId} trong cơ sở dữ liệu");
            
            var works = new WorkViewModel()
            {
                Name = work.Name,
                Description = work.Description,
                Status = (Data.Enums.Status)work.Status,
                Priority = (Data.Enums.Priority)work.Priority,
                Deadline = work.Deadline
            };

            return works;
        }

        public async Task<int> Update(int id, WorkUpdateRequest request)
        {
            var work = await _context.Works.FindAsync(id);
            if (work == null)
            {
                throw new LucasTimetable_Exceptions($"Không tìm thấy bản ghi của công việc: {id}!");
            }

            work.Name = request.Name;
            work.Description = request.Description;
            work.Status = request.Status;
            work.Priority = request.Priority;
            work.Deadline = request.Deadline;

            return await _context.SaveChangesAsync();
        }
    }
}
