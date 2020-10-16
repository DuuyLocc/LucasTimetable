using System;
using System.Collections.Generic;
using System.Text;
using LucasTimetable.Data.Configurations;
using LucasTimetable.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasTimetable.Data.EF
{
    public class Timetable_DBcontext : DbContext
    {
        public Timetable_DBcontext(DbContextOptions options) : base(options)
        {
        }

        //Configuation using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AppConfigConfiguration());
            modelBuilder.ApplyConfiguration(new AppRoleConfiguaration());
            modelBuilder.ApplyConfiguration(new AppUserConfiguaration());
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
            /*base.OnModelCreating(modelBuilder);*/
        }


        //Fundamentals - connection strings
        public DbSet<Work> Works { get; set; }
        public DbSet<AppConfig> AppConfigs { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
    }
}
