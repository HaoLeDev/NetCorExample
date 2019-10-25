using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Models
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }
        public int De_Id { get; set; }
        public string Em_Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string IdentityCardNumber { get; set; }
        public Nullable <bool> Sex { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public Nullable <bool> Status { get; set; }
        public string De_Name { get; set; }

        public string strSex
        {
            get
            {
                return Sex.HasValue && Sex.Value == true ? "Nam" : "Nữ";
            }
        }
        public string strStatus
        {
            get
            {
                return Status.HasValue && Status.Value == true ? "Đang sử dụng" : "Đã khóa";
            }
        }
        public string strBirthDate
        {
            get
            {
                return BirthDate.ToString("dd/MM/yyyy"); 
            }
        } 
    }
}
