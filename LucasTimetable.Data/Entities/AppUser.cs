using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LucasTimetable.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string HoTen { get; set; }
        [DataType(DataType.Date)]
        public DateTime NgaySinh { get; set; }
    }
}
