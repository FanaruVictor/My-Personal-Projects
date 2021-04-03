using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Cart;
using CupcakeShop.Web.Models.Cupcakes;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CupcakeShop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly CupcakeShopDbContext _context;

        public CartController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Cart()
        {
            var entity = _context.Carts.FirstOrDefault();
            if (entity == null)
            {
                CartList List = new CartList()
                {
                    CupcakeDtos = new() { }
                };
                return View(List);
            }

            List<CupcakeQuantityDto> cupcakeDtos = new List<CupcakeQuantityDto>();

            var cupcakeCarts = _context.CupcakeCarts.Include(x => x.Cupcake).ToList();

            foreach (var cupcakeCart in cupcakeCarts)
            {
                if (cupcakeCart.CartId == entity.Id)
                {
                    CupcakeQuantityDto curentCupcakeDto = new CupcakeQuantityDto()
                    {
                        Name = cupcakeCart.Cupcake.Name,
                        Weight = cupcakeCart.Cupcake.Weight,
                        Flavour = cupcakeCart.Cupcake.Flavour,
                        Price = cupcakeCart.Cupcake.Price,
                        Dough = cupcakeCart.Cupcake.Dough,
                        Icing = cupcakeCart.Cupcake.Icing,
                        Expiration = cupcakeCart.Cupcake.Expiration,
                        Producer = cupcakeCart.Cupcake.Producer,
                        Id = cupcakeCart.Cupcake.Id,
                        Stock = cupcakeCart.Cupcake.Stock,
                        Quantity = cupcakeCart.Quantity
                    };
                    cupcakeDtos.Add(curentCupcakeDto);
                }
            }

            CartList cartList = new CartList()
            {
                CartDto = new CartDto()
                {
                    Id = entity.Id,
                    ClientId = entity.Id,
                    Client = entity.Client
                },
                CupcakeDtos = cupcakeDtos
            };
            return View(cartList);
        }

        [HttpGet]
        public IActionResult Delete(int id, int cupcakeId)
        {
            var entity = _context.Carts.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            CupcakeCart cupcakeCart = _context.CupcakeCarts.Include(x => x.Cupcake).
                First(x => x.CupcakeId == cupcakeId);
            cupcakeCart.Cupcake.RestoreStock(cupcakeCart.Quantity);
            _context.CupcakeCarts.Remove(cupcakeCart);
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpPost]
        public IActionResult Add(int id, int clientId)
        {
            var entity = _context.Carts.Include(x => x.CupcakeCarts)
                .ThenInclude(x => x.Cupcake)
                .FirstOrDefault(x => x.ClientId == clientId);
            //?
            if (entity == null)
            {
                entity = new(clientId);

                _context.Carts.Add(entity);
                _context.CupcakeCarts.Add(entity.CupcakeCarts.First());
            }

            entity.AddCupcake(id);
            _context.Update(entity);
            var cupcake = _context.Cupcakes.First(x => x.Id == id);
            cupcake.DecreaseStock();
            _context.SaveChanges();
            return RedirectToAction("Cart");
        }

        public IActionResult Remove(int id, int clientId)
        {
            var entity = _context.Carts.Include(x => x.CupcakeCarts).ThenInclude(x => x.Cupcake)
                .FirstOrDefault(x => x.ClientId == clientId);
            if (entity == null)
            {
                throw new Exception("The cart did not exist");
            }

            entity.RemoveCucpake(id);
            CupcakeCart cupcakeCart = entity.CupcakeCarts.First(x => x.CupcakeId == id);
            if (cupcakeCart.Quantity == 0)
            {
                Delete(entity.Id, id);
            }

            _context.SaveChanges();
            return RedirectToAction("Cart");
        }
    }
}
