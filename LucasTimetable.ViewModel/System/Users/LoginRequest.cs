using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.System.Users
{
    public class LoginRequest
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public bool RememberMe { get; set; }
    }
}
