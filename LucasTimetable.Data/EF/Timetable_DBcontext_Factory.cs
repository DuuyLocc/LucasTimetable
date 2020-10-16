using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LucasTimetable.Data.EF
{
    public class Timetable_DBcontext_Factory : IDesignTimeDbContextFactory<Timetable_DBcontext>
    {
        public Timetable_DBcontext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("LucasTimetableDB");
            var optionsBuilder = new DbContextOptionsBuilder<Timetable_DBcontext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new Timetable_DBcontext(optionsBuilder.Options);
        }
    }
}
