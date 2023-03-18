using System.Collections.Concurrent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext _context;
        public ProductRepository(StoreContext context)
        {
            _context = context;
            
        }

        public async Task<List<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
            .Include(x=>x.ProductBrand)
            .Include(x=>x.ProductType)
            .FirstOrDefaultAsync(x=>x.Id==id);
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _context.Products
            .Include(x=>x.ProductBrand)
            .Include(x=>x.ProductType)
            .AsNoTracking()
            .ToListAsync();
        }

        public Task<List<ProductType>> GetProductTypesAsync()
        {
            return _context.ProductTypes.ToListAsync();
        }
    }
}