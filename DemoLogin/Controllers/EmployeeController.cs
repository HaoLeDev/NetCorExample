using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoLogin.Common;
using DemoLogin.Data;
using DemoLogin.Models;
using DemoLogin.Models.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DemoLogin.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DemoContext _context;

        public EmployeeController(DemoContext context)
        {
            _context = context;
        }

        // GET: EmployeesTest
        public async Task<IActionResult> Index(string search, string sortOrder)
        {
            try
            {
                var nhanvien = from nv in _context.Employees
                               join pb in _context.Departments
                               on nv.De_Id equals pb.Id
                               select new
                               {
                                   Id = nv.Id,
                                   Em_code = nv.Em_Code,
                                   FirstName = nv.FirstName,
                                   LastName = nv.LastName,
                                   BirthDate = nv.BirthDate,
                                   Address = nv.Address,
                                   Phone = nv.Phone,
                                   IdCarNumber = nv.IdentityCardNumber,
                                   Sex = nv.Sex,
                                   Status = nv.Status,
                                   De_Id = nv.De_Id,
                                   De_Name = pb.Name,
                                   De_Desciption = pb.Description
                               };
                List<Department> department = new List<Department>();
                department = _context.Departments.ToList();
                ViewBag.ListDepartment = department;
                //Sắp xếp bản ghi
                ViewData["CodeParam"] = String.IsNullOrEmpty(sortOrder) ? "code_desc" : "";
                ViewData["NameSortParam"] = sortOrder == "LastName" ? "name_desc" : "LastName";
                switch (sortOrder)
                {
                    case "name_desc": nhanvien = nhanvien.OrderByDescending(s => s.LastName);
                        break;
                    case "code_desc": nhanvien = nhanvien.OrderByDescending(s => s.Em_code);
                        break;
                    default: nhanvien = nhanvien.OrderBy(s => s.Em_code);
                        break;
                }
                //Tìm kiếm theo mã nhân viên, tên nhân viên
                if (!String.IsNullOrWhiteSpace(search))
                {
                   nhanvien= nhanvien.Where(s => s.Em_code.ToLower().Contains(search) || s.FirstName.ToLower().Contains(search) || s.LastName.ToLower().Contains(search));
                }
                ViewData["CurrentFilter"] = search;
                var lst = nhanvien.ToList();
                int count = nhanvien.Count();
                var entity = new List<EmployeeViewModel>();
                foreach (var temp in lst)
                {
                    var t = new EmployeeViewModel();
                    t.Id = temp.Id;
                    t.Em_Code = temp.Em_code;
                    t.FirstName = temp.FirstName +" "+ temp.LastName;
                    //t.LastName = temp.LastName;
                    t.BirthDate = temp.BirthDate;
                    t.IdentityCardNumber = temp.IdCarNumber;
                    t.Phone = temp.Phone;
                    t.Sex = temp.Sex;
                    t.Address = temp.Address;
                    t.Status = temp.Status;
                    t.De_Name = temp.De_Name;
                    entity.Add(t);
                }
                return View(entity);

            }
            catch (Exception e)
            {
                return Json("error", e.Message.ToString());
            }
        }
        //public IActionResult Create()
        //{
        //    return View();
        //}
        public IActionResult Create( Employee employee)
        {
            _context.Add(employee);
             _context.SaveChanges();
            //return RedirectToAction(nameof(Index));
            return Ok(employee);
        }
        public IActionResult GetById(int id)
        {
            var nv = _context.Employees.Where(n => n.Id == id).FirstOrDefault();
            return Ok(nv);
        }
        public IActionResult Update(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return Ok(employee);
        }
        public IActionResult Delete(int id)
        {
            var nv = _context.Employees.Where(s => s.Id == id).FirstOrDefault();
            _context.Remove(nv);
            _context.SaveChanges();
            return Ok("Xóa nhân viên thành công!");
        }
        public async Task<IActionResult> Detail(int id)
        {
            var nhanvien = _context.Employees.Where(s => s.Id == id).FirstOrDefault();
            EmployeeViewModel viewModel = new EmployeeViewModel();
            
            viewModel.Em_Code = nhanvien.Em_Code;
            viewModel.Id = nhanvien.Id;
            var Name = nhanvien.FirstName + " " + nhanvien.LastName;
            viewModel.FirstName = Name;
            //viewModel.LastName = nhanvien.LastName;
            viewModel.De_Id = nhanvien.De_Id;
            if (viewModel.De_Id == 1)
                viewModel.De_Name = "Phòng R&D";
            else if (viewModel.De_Id == 2)
                viewModel.De_Name = "Phòng Hành chính - Nhân sự";
            else if (viewModel.De_Id == 3)
                viewModel.De_Name = "Phòng Kỹ thuật";
            else if (viewModel.De_Id == 4)
                viewModel.De_Name = "Phòng Kế toán";
            viewModel.Image = nhanvien.Image;
            viewModel.IdentityCardNumber = nhanvien.IdentityCardNumber;
            viewModel.Address = nhanvien.Address;
            DateTime d = nhanvien.BirthDate;
            d.ToString("dd/MM/yyyy");
             viewModel.BirthDate= d;
            viewModel.Sex = nhanvien.Sex;
            viewModel.Status = nhanvien.Status;
            viewModel.Phone = nhanvien.Phone;
            return Ok(viewModel);
        }
    }
}