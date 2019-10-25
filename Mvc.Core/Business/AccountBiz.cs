using Mvc.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Core.Business
{
    public class AccountBiz
    {
        private PersonTestContext db = new PersonTestContext();
        public Account GetbyId(string userName)
        {
            var result = db.Account.SingleOrDefault(a => a.UserName == userName);
            return result;
        }
        public int Login(string userName, string password)
        {
            var result = db.Account.SingleOrDefault(a => a.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Password == password)
                    return 1;
                else
                    return -2;
            }
        }
    }
}
