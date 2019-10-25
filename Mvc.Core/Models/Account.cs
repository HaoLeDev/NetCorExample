using System;
using System.Collections.Generic;

namespace Mvc.Core.Models
{
    public partial class Account
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? Created { get; set; }
    }
}
