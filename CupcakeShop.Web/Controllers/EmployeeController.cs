using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace CupcakeShop.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly CupcakeShopDbContext _context;

        public EmployeeController(CupcakeShopDbContext context)
        {
            _context = context;
        }




        public IActionResult Employees(int id)
        {
            List<EmployeeDto> employees = new List<EmployeeDto>();
            foreach (var employee in _context.Employees)
            {
                if (employee.ShopId == id)
                {
                    EmployeeDto curentEmployee = new EmployeeDto
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Occupation = employee.Occupation,
                        Salary = employee.Salary,
                        Seniority = employee.Seniority,
                        HoursPerDay = employee.HoursPerDay,
                        ShopId=employee.ShopId
                    };
                    employees.Add(curentEmployee);
                }
            }
            return View(new EmployeeList
            {
                Employees = employees,
                ShopId = id
            });
        }

        //Get-Create
        public IActionResult Create(int id)
        {
            ViewBag.ShopId = id;
            return View();
        }

        //Post-Create
        [HttpPost]
        public IActionResult Create(EmployeInsertRequest request)
        {
            Employee employee = new Employee(request.FirstName, request.LastName, request.Salary, request.Occupation,
                request.HoursPerDay, request.Seniority,request.ShopId);
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Shops","Shop");
        }

        public IActionResult Edit(int id)
        {
            var entity = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            EmployeeEdit curentEmployee = new EmployeeEdit
            {
                FirstName=entity.FirstName,
                LastName = entity.LastName,
                Occupation = entity.Occupation,
                Salary = entity.Salary,
                Seniority = entity.Seniority,
                 ShopId = entity.ShopId,
                 HoursPerDay = entity.HoursPerDay

            };
            ViewBag.ShopId = entity.ShopId;
            return View(curentEmployee);
        }
        [HttpPost]
        public IActionResult Edit(int id,EmployeeEdit employee)
        {
            var entity = _context.Employees.FirstOrDefault(x => x.Id == id);
            entity.UpdateProprieties(employee.Salary,employee.Occupation,employee.HoursPerDay,employee.Seniority);
            _context.SaveChanges();
            return RedirectToAction("Employees", new {id = employee.ShopId});
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(entity);
            _context.SaveChanges();
            return RedirectToAction("Shops","Shop");
        }
    }
}
