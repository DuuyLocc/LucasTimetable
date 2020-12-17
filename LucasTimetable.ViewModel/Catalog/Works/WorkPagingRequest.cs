using LucasTimetable.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.Catalog.Works
{
    public class WorkPagingRequest : PagingRequestBase
    {
        public string KeyWord { get; set; }
    }
}
