using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.Common
{
    public class PagedResult<T> : PagingRequestBase
    {
        public List<T> Items { get; set; }
    }
}
