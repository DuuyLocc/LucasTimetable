using System;
using System.Collections.Generic;
using System.Text;
using LucasTimetable.Data.Enums;

namespace LucasTimetable.ViewModel.Catalog.Works
{
    public class WorkCreateRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Status Status { set; get; }
        public Priority Priority { set; get; }
        public DateTime Deadline { set; get; }

    }
}
