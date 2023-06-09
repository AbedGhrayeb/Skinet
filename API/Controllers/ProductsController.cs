using Microsoft.AspNetCore.Mvc;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications.ProductSpicifications;
using AutoMapper;
using API.Dtos;
using API.Errors;

namespace API.Controllers
{
    [Produces("application/json")]
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _brandRepo;
        private readonly IGenericRepository<ProductType> _typeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepo,IGenericRepository<ProductBrand> brandRepo,
                IGenericRepository<ProductType> typeRepo,IMapper mapper)
        {
            _mapper = mapper;
            _typeRepo = typeRepo;
            _brandRepo = brandRepo;
            _productRepo = productRepo;
            
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductToReturnDto),StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>>  GetProducts()
        {
            var spec= new ProductWithBrandAndTypeSpicification();
            var product= await _productRepo.ListWithSpecAsync(spec);
            return Ok(_mapper.Map<IReadOnlyList<ProductToReturnDto>>(product));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductToReturnDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec= new ProductWithBrandAndTypeSpicification(id);
            var product= await _productRepo.GetEntityWithSpecAsync(spec);
            if(product is null)
                return NotFound(new ApiErrorResponse((int)StatusCodes.Status404NotFound, $"product with id {id} not found"));
            return Ok(_mapper.Map<ProductToReturnDto>(product));
        }
         [HttpGet("brands")]
        [ProducesResponseType(typeof(ProductType), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductBrand>>>  GetProductBrands()
        {
                return await _brandRepo.ListAllAsync();
        }
         [HttpGet("types")]
        [ProducesResponseType(typeof(ProductType), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProductType>>>  GetProductTypes()
        {
                return await _typeRepo.ListAllAsync();
        }
    }
}