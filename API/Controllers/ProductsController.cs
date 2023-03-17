using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure.Data;
using Core.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly StoreContext _context;
        public ProductsController(StoreContext context)
        {
            _context = context;
            
        }
        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {var product= _context.Products.Find(id);
            if(product is null)
                return NotFound();
            return product;
        }
    }
}