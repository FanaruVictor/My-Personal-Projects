using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
//using ASP;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Employee;
using CupcakeShop.Web.Models.Shop;
using Microsoft.AspNetCore.Mvc; //using CupcakeShop.API.Data;
//using CupcakeShop.API.Dtos.Shop;
//using CupcakeShop.API.Entities;

namespace CupcakeShop.Web.Controllers
{
    public class ShopController : Controller
    {
        public CupcakeShopDbContext _context;

        public ShopController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Shops()
        {
            Shop shop = _context.Shops.FirstOrDefault();
            if (shop == null)
            {
                ShopList shopList = new ShopList()
                {
                    shopDto = null,
                    employeesList =  null
                };

                return View(shopList);
            }
            List<EmployeeDto> employees = new List<EmployeeDto>();
            foreach (var employee in _context.Employees)
            {
                EmployeeDto curentEmployee = new EmployeeDto()
                {
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    HoursPerDay = employee.HoursPerDay,
                    Occupation = employee.Occupation,
                    Salary = employee.Salary,
                    Seniority = employee.Seniority,
                    Id = employee.Id,
                    ShopId=employee.ShopId
                };
                employees.Add(curentEmployee);
            }
            ShopList secondShopList = new ShopList()
            {
                shopDto = new ShopDto()
                {
                  Id = shop.Id,
                  Name=shop.Name,
                  Country = shop.Country,
                  City = shop.City,
                  Street = shop.Street,
                  Block = shop.Block,
                  Floor = shop.Floor,
                  Suit = shop.Suit,
                  Capital = shop.Capital
                },
                employeesList =  employees
            };

            return View(secondShopList);

        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit(int id)
        {
            var entity = _context.Shops.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            ShopEdit shop = new ShopEdit
            {
                Name = entity.Name,
                Country = entity.Country,
                City = entity.City,
                Street = entity.Street,
                Block = entity.Block,
                Floor = entity.Floor,
                Suit = entity.Suit,
                Capital = entity.Capital
            };
            return View(shop);
        }

        [HttpPost]
        public IActionResult Edit(int id,ShopEdit shop)
        {
            var entity = _context.Shops.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }
            entity.UpdateProprieties(shop.Name,shop.Country,shop.City,shop.Street,shop.Block,shop.Floor,shop.Suit,shop.Capital);
            _context.SaveChanges();
            return RedirectToAction("Shops");
        }

    }
}
