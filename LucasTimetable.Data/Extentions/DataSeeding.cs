using LucasTimetable.Data.Entities;
using LucasTimetable.Data.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.Data.Extentions
{
    // ModelBuilderExtensions
    public static class DataSeeding
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTile", Value = "This is home page of LucasTimetable" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of LucasTimetable" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of LucasTimetable" }
                );

            var roleId  = new Guid("7E2DE1EE-B97B-4698-ABE4-C22A0332B2C9");
            var roleId2 = new Guid("DDCFD40F-0C20-4BBD-AFBF-5936032DDDE5");
            var adminId = new Guid("8DD4E4E7-CBB1-4DB8-8CD8-3024401AFC74");

            modelBuilder.Entity<AppRole>().HasData(
                new AppRole
                {
                    Id = roleId,
                    Name = "admin",
                    NormalizedName = "admin",
                    Description = "Quản trị viên"
                },
                new AppRole
                {
                    Id = roleId2,
                    Name = "user",
                    NormalizedName = "user",
                    Description = "Người dùng"
                }
            );

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "letruongduyloc@gmail.com",
                NormalizedEmail = "letruongduyloc@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Admin@123"),
                SecurityStamp = string.Empty,
                Ho = "Le",
                Ten = "Loc",
                HoTen = "Le Loc",
                NgaySinh = new DateTime(1998, 10, 29)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(
                new IdentityUserRole<Guid>
                {
                    RoleId = roleId,
                    UserId = adminId
                });

            modelBuilder.Entity<Work>().HasData(
                new Work
                {
                    Id = 1,
                    Name = "Note timetable",
                    Description = "Make a plan",
                    Status = Status.todo,
                    Priority = Priority.yes,
                    Deadline = new DateTime(2020, 10, 23)
                    //DateTime.Now
                }

                );
        }
    }
}
