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
            return RedirectToAction("ConfirmOrder",new{clientId=clientId});
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
            List<CupcakeDto> cupcakeDtos = new List<CupcakeDto>();
            var cart = _context.Carts.Include(x => x.CupcakeCarts).ThenInclude(x => x.Cupcake).FirstOrDefault(x => x.ClientId == clientId);
            if (cart == null)
            {
                return NotFound();
            }

            foreach (var cupcakeCart in cart.CupcakeCarts)
            {
                CupcakeDto curentCupcakeDto = new()
                {
                    Name = cupcakeCart.Cupcake.Name,
                    Weight = cupcakeCart.Cupcake.Weight,
                    Price = cupcakeCart.Cupcake.Price,
                    Producer = cupcakeCart.Cupcake.Producer,
                    Dough = cupcakeCart.Cupcake.Dough,
                    Expiration = cupcakeCart.Cupcake.Expiration,
                    Flavour = cupcakeCart.Cupcake.Flavour,
                    Icing = cupcakeCart.Cupcake.Icing
                };
                cupcakeDtos.Add(curentCupcakeDto);
            }

            OrderDto orderDto = new OrderDto()
            {
                Emergency = false,
                ClientId = clientId,
                DateOrder = DateTime.Now,
                 DateDelivery = DateTime.Now.AddDays(3),
                StatusOrder = Order.StatusType.OnHold
            };
            ConfirmOrderList confirmOrderList = new()
            {
                ClientDto = clientDto,
                CupcakeDtos = cupcakeDtos,
                OrderDto = orderDto
            };
            return View(confirmOrderList);
        }
        //Post-ConfirmOrder
        [HttpPost]
        public IActionResult ConfirmOrder(int id,ConfirmOrderList confirmOrderList)
        {
            return Ok();
        }

        //get-edit
        public IActionResult EditOrder()
        {
            return Ok();
        }
    }
}
