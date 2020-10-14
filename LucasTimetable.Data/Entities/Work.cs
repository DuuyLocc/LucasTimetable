﻿using LucasTimetable.Data.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.Data.Entities
{
    public class Work
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string? Description { set; get; }
        public Status Status { set; get; }
        public Priority? Driority { set; get; }
        public DateTime? Deadline { set; get; }
    }
}
