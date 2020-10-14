using System;
using System.Collections.Generic;
using System.Text;
using LucasTimetable.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasTimetable.Data.EF
{
    public class Timetable_DBcontext : DbContext
    {
        public Timetable_DBcontext(DbContextOptions options) : base(options)
        {
        }

        //Fundamentals - connection strings
        public DbSet<Work> Works { get; set; }
    }
}
