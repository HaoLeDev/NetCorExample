using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Data
{
    [Table("Employee")]
    public class Employee
    {
        public int Id { get; set; }
        public int De_Id { get; set; }
        public string Em_Code { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Phone { get; set; }
        public string IdentityCardNumber { get; set; }
        public bool Sex { get; set; }
        public string Address { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        //public virtual ICollection<Department> Departments { get; set; }
    }
}
