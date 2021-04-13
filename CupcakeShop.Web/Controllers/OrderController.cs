using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
//using CupcakeShop.API.Data;
//using CupcakeShop.API.Dtos.Order;
//using CupcakeShop.API.Entities;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Client;
using CupcakeShop.Web.Models.Cupcakes;
using CupcakeShop.Web.Models.Order;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CupcakeShop.Web.Controllers
{
    public class OrderController : Controller
    {
        private readonly CupcakeShopDbContext _context;

        public OrderController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        //Get-order
        public IActionResult ConfirmPersonalDetalies(int clientId)
        {
            OrderInsertRequest orderInsertRequest = new OrderInsertRequest();
            orderInsertRequest.ClientDto = new();
            orderInsertRequest.ClientId = clientId;
            return View(orderInsertRequest);
        }

        [HttpPost]
        public IActionResult ConfirmPersonalDetalies(int clientId, OrderInsertRequest request)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == clientId);
            if (entity == null)
            {
                return NotFound();
            }

            entity.UpdateAddress(request.ClientDto.Street, request.ClientDto.Block, request.ClientDto.Floor,
                request.ClientDto.Suit);
            entity.UpdateContact(request.ClientDto.FirstName, request.ClientDto.LastName, request.ClientDto.PhoneNumber,
                request.ClientDto.Email);
            entity.UpdateType(request.ClientDto.Type);
            _context.SaveChanges();
            return RedirectToAction("ConfirmOrder", new {clientId = clientId});
        }

        //Get-ConfirmOrder
        public IActionResult ConfirmOrder(int clientId)
        {
            Client client = _context.Clients.First(x => x.Id == clientId);
            ClientDto clientDto = new()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Street = client.Street,
                Block = client.Block,
                Floor = client.Floor,
                Suit = client.Suit
            };
            List<CupcakeQuantityDto> cupcakeQuantityDto = new List<CupcakeQuantityDto>();
            var cart = _context.Carts.Include(x => x.CupcakeCarts).ThenInclude(x => x.Cupcake)
                .FirstOrDefault(x => x.ClientId == clientId);
            if (cart == null)
            {
                return NotFound();
            }

            foreach (var cupcakeCart in cart.CupcakeCarts)
            {
                CupcakeQuantityDto curentCupcakeDto = new()
                {
                    Name = cupcakeCart.Cupcake.Name,
                    Weight = cupcakeCart.Cupcake.Weight,
                    Price = cupcakeCart.Cupcake.Price,
                    Producer = cupcakeCart.Cupcake.Producer,
                    Dough = cupcakeCart.Cupcake.Dough,
                    Expiration = cupcakeCart.Cupcake.Expiration,
                    Flavour = cupcakeCart.Cupcake.Flavour,
                    Icing = cupcakeCart.Cupcake.Icing,
                    Quantity = cupcakeCart.Quantity
                };
                cupcakeQuantityDto.Add(curentCupcakeDto);
            }


            ConfirmOrderList confirmOrderList = new()
            {
                ClientDto = clientDto,
                CupcakeQuantityDto = cupcakeQuantityDto
            };
            return View(confirmOrderList);
        }

        //Post-ConfirmOrder
        [HttpPost]
        public IActionResult ConfirmOrder(int clientId, ConfirmOrderList confirmOrderList)
        {
            Order order = new Order(DateTime.Now, DateTime.Now.AddDays(3), clientId, Order.StatusType.Comfirmed, false, 1);
            _context.Orders.Add(order);
            _context.SaveChanges();

            foreach (var cupcakeDto in confirmOrderList.CupcakeQuantityDto)
            {
                Cupcake cupcake = _context.Cupcakes.First(x => x.Id == cupcakeDto.Id);
                CupcakeOrder cupcakeOrder = new CupcakeOrder(cupcake.Id, order.Id,
                    cupcake.CupcakeCarts.First(x => x.CupcakeId == cupcake.Id).Quantity);
                _context.CupcakeOrders.Add(cupcakeOrder);
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Home");
        }

        

        //get-edit
        public IActionResult EditOrder(int clientId)
        {
            Client client = _context.Clients.First(x => x.Id == clientId);
            ClientDto clientDto = new()
            {
                FirstName = client.FirstName,
                LastName = client.LastName,
                PhoneNumber = client.PhoneNumber,
                Email = client.Email,
                Street = client.Street,
                Block = client.Block,
                Floor = client.Floor,
                Suit = client.Suit
            };
            List<CupcakeQuantityDto> cupcakeQuantityDto = new List<CupcakeQuantityDto>();
            var cart = _context.Carts.Include(x => x.CupcakeCarts).ThenInclude(x => x.Cupcake)
                .FirstOrDefault(x => x.ClientId == clientId);
            if (cart == null)
            {
                return NotFound();
            }

            foreach (var cupcakeCart in cart.CupcakeCarts)
            {
                CupcakeQuantityDto curentCupcakeDto = new()
                {
                    Id=cupcakeCart.Cupcake.Id,
                    Name = cupcakeCart.Cupcake.Name,
                    Weight = cupcakeCart.Cupcake.Weight,
                    Price = cupcakeCart.Cupcake.Price,
                    Producer = cupcakeCart.Cupcake.Producer,
                    Dough = cupcakeCart.Cupcake.Dough,
                    Expiration = cupcakeCart.Cupcake.Expiration,
                    Flavour = cupcakeCart.Cupcake.Flavour,
                    Icing = cupcakeCart.Cupcake.Icing,
                    Stock = cupcakeCart.Cupcake.Stock,
                    Quantity = cupcakeCart.Quantity

                };
                cupcakeQuantityDto.Add(curentCupcakeDto);
            }


            ConfirmOrderList confirmOrderList = new()
            {
                ClientDto = clientDto,
                CupcakeQuantityDto = cupcakeQuantityDto,
            };
            return View(confirmOrderList);
            
        }

        [HttpPost]
        public IActionResult EditOrder(int clientId, ConfirmOrderList confirmOrderList)
        {
            var entity = _context.Clients.First(x => x.Id == clientId);
            entity.UpdateContact(confirmOrderList.ClientDto.FirstName, confirmOrderList.ClientDto.LastName,
                confirmOrderList.ClientDto.PhoneNumber, confirmOrderList.ClientDto.Email);
            entity.UpdateType(confirmOrderList.ClientDto.Type);
            entity.UpdateAddress(confirmOrderList.ClientDto.Street, confirmOrderList.ClientDto.Block,
                confirmOrderList.ClientDto.Floor, confirmOrderList.ClientDto.Suit);
            _context.SaveChanges();
            return RedirectToAction("ConfirmOrder",new {clientId=1,confirmOrderList});
           
        }
        [HttpGet]
        public IActionResult Add(int id, int clientId)
        {
            var entity = _context.Carts.Include(x => x.CupcakeCarts)
                .ThenInclude(x => x.Cupcake)
                .First(x => x.ClientId == clientId);
            
            entity.AddCupcake(id);
            _context.Update(entity);
            
            var cupcake = _context.Cupcakes.First(x => x.Id == id);
            cupcake.DecreaseStock();
            _context.SaveChanges();
            return RedirectToAction("EditOrder", new{clientId=1});

            
        }
        [HttpGet]
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
                Delete(id);
            }

            _context.SaveChanges();
            return RedirectToAction("EditOrder", new{clientId=1});
        }
        
        [HttpGet]
        public IActionResult Delete( int cupcakeId)
        {
            
            CupcakeCart cupcakeCart = _context.CupcakeCarts.Include(x => x.Cupcake).
                First(x => x.CupcakeId == cupcakeId);
            cupcakeCart.Cupcake.RestoreStock(cupcakeCart.Quantity);
            _context.CupcakeCarts.Remove(cupcakeCart);
            _context.SaveChanges();
            return RedirectToAction("EditOrder", new{clientId=1});
        }
    }
}
