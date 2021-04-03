using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using CupcakeShop.Web.Data;
using CupcakeShop.Web.Entities;
using CupcakeShop.Web.Models.Candy;
//using CupcakeShop.API.Data;
//using CupcakeShop.API.Dtos.Candy;
//using CupcakeShop.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;

namespace CupcakeShop.Web.Controllers
{
    public class CandyController:Controller
    {
        private readonly CupcakeShopDbContext _context;

        public CandyController(CupcakeShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Put(CandyInsertRequest request)
        {
            Candy candy = new Candy(request.CandyName, request.CandyFlavour, request.Suger, request.Price,
                request.Color, request.Shape);
            _context.Candies.Add(candy);
            _context.SaveChanges();
            return new OkObjectResult(candy);
        }

        [HttpGet("all")]
        public List<Candy> Get()
        {
            List<Candy> candies = new List<Candy>();
            foreach (var candy in _context.Candies)
            {
                candies.Add(candy);
            }

            return candies;
        }

        [HttpGet("/old/{id}")]
        public IActionResult Get(int id)
        {
            var entity = _context.Candies.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            return new OkObjectResult(new CandyDto()
            {
                Id = entity.Id,
                CandyName = entity.CandyName,
                CandyFlavoure = entity.CandyFlavour,
                Suger = entity.Sugar,
                Price = entity.Price,
                Color = entity.Color,
                Shape = entity.Shape
            });
        }

        [HttpPatch("/old/{id}")]
        public IActionResult Patch(int id, CandyDto candy)
        {
            var entity = _context.Candies.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            entity.UpdateProprieties(candy.CandyName,candy.CandyFlavoure,candy.Price,candy.Color,candy.Shape);
            _context.SaveChanges();
            return new ObjectResult(entity);
        }

        [HttpDelete("/old/{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Candies.FirstOrDefault(x => x.Id == id);
            if (entity == null)
            {
                return NotFound();
            }

            _context.Candies.Remove(entity);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("all")]
        public IActionResult Delete()
        {
            foreach (var candy in _context.Candies)
            {
                _context.Candies.Remove(candy);
            }

            _context.SaveChanges();
            return NoContent();
        }


    }

}
