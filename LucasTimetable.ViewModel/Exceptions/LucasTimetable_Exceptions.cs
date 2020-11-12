using System;
using System.Collections.Generic;
using System.Text;

namespace LucasTimetable.ViewModel.Exceptions
{
    public class LucasTimetable_Exceptions : Exception
    {
/*        public EmployeeListNotFoundException()
        {
        }*/

        public LucasTimetable_Exceptions(string message)
            : base(message)
        {
        }

        public LucasTimetable_Exceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
