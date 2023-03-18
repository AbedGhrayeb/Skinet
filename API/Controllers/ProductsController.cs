using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
            
        }
        [HttpGet]
        public async Task<ActionResult<List<Product>>>  GetProducts()
        {
                return await _productRepository.GetProductsAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {var product= await _productRepository.GetProductByIdAsync(id);
            if(product is null)
                return NotFound();
            return product;
        }
         [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>>  GetProductBrands()
        {
                return await _productRepository.GetProductBrandsAsync();
        }
         [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>>  GetProductTypes()
        {
                return await _productRepository.GetProductTypesAsync();
        }
    }
}