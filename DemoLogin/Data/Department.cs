using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Data
{
    [Table("Department")]
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Nullable<bool> Status { get; set; }

        //public virtual ICollection<Employee> Employees { get; set; }
    }
}
