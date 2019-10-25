using DemoLogin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoLogin.Business
{
    public static class EmployeeBiz
    {
        /// <summary>
        /// Tìm nhân viên theo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetById(int id)
        {
            using( DemoContext db= new DemoContext())
            {
                var nv = db.Employees.Where(n => n.Id == id).FirstOrDefault();
                return nv;
            }
        }
    }
}
