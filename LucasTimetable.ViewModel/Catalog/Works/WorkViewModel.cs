using LucasTimetable.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.Catalog.Works
{
    public class WorkViewModel
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string? Description { set; get; }
        public Status Status { set; get; }
        public Priority Priority { set; get; }
        public DateTime Deadline { set; get; }
    }
}
