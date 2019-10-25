using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Models
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }

        public string strStatus
        {
            get
            {
                return Status.HasValue && Status.Value == true ? "<span class='lable lable-success'>Đang sử dụng</span>" : "<span class='lable lable-success'>Đã khóa</span>";
            }
        }
    }
}
