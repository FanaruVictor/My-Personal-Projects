using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
//using CupcakeShop.API.Data;
//using CupcakeShop.API.Dtos;
//using CupcakeShop.API.Dtos.Client;
//using CupcakeShop.API.Entities;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace CupcakeShop.Web.Controllers
{
    public class ClientController : Controller
    {
        public CupcakeShopDbContext _context;

        public ClientController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Put(ClientInsertRequest request)
        {
            Client client = new Client(request.FirstName, request.LastName, request.PhoneNumer, request.Email, request.Type,
                request.Street, request.Block, request.Floor, request.Suit);
            _context.Clients.Add(client);
            _context.SaveChanges();
            return new OkObjectResult(client);
        }

        [HttpGet("/old/{id}")]
        public IActionResult Get(int id)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return new OkObjectResult(entity);
        }

        [HttpGet("/old/all")]
        public IActionResult Get()
        {
            List<Client> clients = new List<Client>();
            foreach (var client in _context.Clients)
            {
                clients.Add(client);
            }

            return new OkObjectResult(clients);
        }

        [HttpPatch("updateContact/{id}")]
        public IActionResult Patch(int id, ClientUpdateContactDto client)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return  NotFound();
            }
            entity.UpdateContact(client.FirstName, client.LastName, client.PhoneNumber, client.Email);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("updateAddress/{id}")]
        public IActionResult Patch(int id, ClientUpdateAddressDto client)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.UpdateAddress(client.Street, client.Block, client.Floor, client.Suit);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPatch("updateType/{id}")]
        public IActionResult Patch(int id, ClientUpdateTypeDto client)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.UpdateType(client.Type);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Clients.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("all")]
        public IActionResult Delete()
        {
            foreach (var client in _context.Clients)
            {
                _context.Clients.Remove(client);
            }

            return NoContent();
        }


    }
}
