﻿using LucasTimetable.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LucasTimetable.ViewModel.Catalog.Works
{
    public class WorkUpdateRequest
    {
        public int Id { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public Status Status { set; get; }
        public Priority Priority { set; get; }

        [DataType(DataType.Date)]
        public DateTime Deadline { set; get; }
    }
}
