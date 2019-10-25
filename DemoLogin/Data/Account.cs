using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Data
{
    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
