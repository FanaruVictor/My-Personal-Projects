using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models;
using CupcakeShop.Web.Models.Cupcakes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CupcakeShop.Web.Controllers
{
    public class CupcakeController : Controller
    {
        private readonly CupcakeShopDbContext _context;

        public CupcakeController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        //Get-Create
        public IActionResult Create()
        {
            return View();
        }

        //Post-Create
        [HttpPost]
        public IActionResult Create(CupcakeInsertRequest request)
        {
            Cupcake cupcake = new Cupcake(request.Name, request.Weight, request.Price, request.Producer,
                request.Flavour, request.Expiration, request.Dough, request.Icing, request.Gluten, request.Stock);
            _context.Cupcakes.Add(cupcake);
            _context.SaveChanges();
            return RedirectToAction("Cupcakes");
        }

        //Get all cupcakes
        public IActionResult Cupcakes()
        {
            List<CupcakeDto> _cupcakes = new List<CupcakeDto>();
            foreach (var cupcake in _context.Cupcakes)
            {
                CupcakeDto curentCupcake = new CupcakeDto
                {
                    Id = cupcake.Id,
                    Weight = cupcake.Weight,
                    Price = cupcake.Price,
                    Producer = cupcake.Producer,
                    Flavour = cupcake.Flavour,
                    Expiration = cupcake.Expiration,
                    Dough = cupcake.Dough,
                    Icing = cupcake.Icing,
                    Candies = cupcake.Candies,
                    Name = cupcake.Name,
                    Stock = cupcake.Stock
                };

                _cupcakes.Add(curentCupcake);
            }

            return View(_cupcakes);
        }


        public IActionResult Edit(int id)
        {
            var cupcake = _context.Cupcakes.FirstOrDefault(x => x.Id == id);

            if (cupcake == null)
            {
                return NotFound();
            }

            CupcakeEdit curentCupcake = new CupcakeEdit
            {
                Price = cupcake.Price,
                Producer = cupcake.Producer,
                Weight = cupcake.Weight,
                Flavour = cupcake.Flavour,
                Dough = cupcake.Dough,
                Icing = cupcake.Icing,
                Gluten = cupcake.Gluten,
                Name = cupcake.Name,
                Stock = cupcake.Stock
            };

            curentCupcake.WeightOptions = new()
            {
                new()
                {
                    Text = Cupcake.Cantity.Small + "(150g)",
                    Value = Cupcake.Cantity.Small.ToString()
                },
                new()
                {
                    Text = Cupcake.Cantity.Medium + "(300g)",
                    Value = Cupcake.Cantity.Medium.ToString()
                },
                new()
                {
                    Text = Cupcake.Cantity.Large + "(450g)",
                    Value = Cupcake.Cantity.Large.ToString()
                }
            };

            curentCupcake.DoughOptions = new()
            {
                new()
                {
                    Text = Cupcake.DoughType.WholemealFlour.ToString(),
                    Value = Cupcake.DoughType.WholemealFlour.ToString()
                },
                new()
                {
                    Text = Cupcake.DoughType.ProteicFlour.ToString(),
                    Value = Cupcake.DoughType.ProteicFlour.ToString()
                },
                new()
                {
                    Text = Cupcake.DoughType.NormalFlour.ToString(),
                    Value = Cupcake.DoughType.NormalFlour.ToString()
                }
            };
            curentCupcake.IcingOptions = new()
            {
                new()
                {
                    Text = "Black Chocolate",
                    Value = Cupcake.IcingType.BlackChocolate.ToString()
                },
                new()
                {
                    Text = "Milk Chocolate",
                    Value = Cupcake.IcingType.MilkChocolate.ToString()
                },
                new()
                {
                    Text = "While Chocolate",
                    Value = Cupcake.IcingType.WhiteChocolate.ToString()
                },
                new()
                {
                    Text = "Caramel",
                    Value = Cupcake.IcingType.Caramel.ToString()
                },
                new()
                {
                    Text = "Burn Sugar",
                    Value = Cupcake.IcingType.BurnSugar.ToString()
                }
            };

            curentCupcake.GlutenOptions = new()
            {
                new()
                {
                    Text = Cupcake.GlutenType.Yes.ToString(),
                    Value = Cupcake.GlutenType.Yes.ToString()
                },
                new()
                {
                    Text = Cupcake.GlutenType.No.ToString(),
                    Value = Cupcake.GlutenType.No.ToString()
                }
            };

            return View(curentCupcake);
        }

        [HttpPost]
        public IActionResult Edit(int id, CupcakeEdit cupcakeEdit)
        {
            var entity = _context.Cupcakes.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return NotFound();
            }

            entity.UpdateProprieties(cupcakeEdit.Name, cupcakeEdit.Weight, cupcakeEdit.Producer, cupcakeEdit.Dough,
                cupcakeEdit.Gluten, cupcakeEdit.Price, cupcakeEdit.Flavour, cupcakeEdit.Icing,cupcakeEdit.Stock);
            _context.SaveChanges();
            return RedirectToAction("Cupcakes");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var entity = _context.Cupcakes.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Cupcakes.Remove(entity);
            _context.SaveChanges();
            return RedirectToAction("Cupcakes");
        }


        //Post-AddToCart
        [HttpPost]
        public IActionResult AddToCart(int id, int clientId)
        {
            var entity = _context.Carts.Include(x => x.CupcakeCarts)
                .ThenInclude(x => x.Cupcake)
                .FirstOrDefault(x => x.ClientId == clientId);
            if (entity == null)
            {
                entity = new(clientId);
                _context.Carts.Add(entity);
                _context.SaveChanges();
                CupcakeCart cupcakeCart = new CupcakeCart(id, entity.Id);
                cupcakeCart.UpdateQuantity(0);
                _context.CupcakeCarts.Add(cupcakeCart);
                _context.SaveChanges();
                return RedirectToAction("Cupcakes");
            }

            entity.AddCupcake(id);
            var cupcake = _context.Cupcakes.First(x => x.Id == id);

            cupcake.DecreaseStock();
            _context.SaveChanges();
            return RedirectToAction("Cupcakes");
        }
    }
}
