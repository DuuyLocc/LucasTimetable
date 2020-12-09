using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using LucasTimetable.Data.Enums;

namespace LucasTimetable.ViewModel.Catalog.Works
{
    public class WorkCreateRequest
    {
        [Required(ErrorMessage = "Hãy nhập tên công việc!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Hãy nhập mô tả công việc!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Hãy chọn trạng thái công việc!")]
        public Status Status { set; get; }

        [Required(ErrorMessage = "Hãy chọn mức độ ưu tiên cho công việc!")]
        public Priority Priority { set; get; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Hãy chọn dealine cho công việc!")]
        public DateTime Deadline { set; get; }
        /*        public DateTime Deadline
                {
                    get
                    {
                        return this.dateCreated.HasValue
                           ? this.dateCreated.Value
                           : DateTime.Today;
                    }

                    set { this.dateCreated = value; }
                }
                private DateTime? dateCreated = null;*/


    }
}
