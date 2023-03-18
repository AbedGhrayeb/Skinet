using System.Text.Json;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Data.SeedData
{
    public  class StoreContextSeed
    {
        public static void SeedStoreData(StoreContext context,ILoggerFactory loggerFactory)
        {
            try
            {
            if (!context.ProductBrands.Any())
            {
                var brandsData= File.ReadAllText("../Infrastructure/Data/SeedData/JsonFiles/brands.json");
                var brands=JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if(brands!=null && brands.Any())
                    context.ProductBrands.AddRange(brands);
            }
             if (!context.ProductTypes.Any())
            {
                var typesData= File.ReadAllText("../Infrastructure/Data/SeedData/JsonFiles/types.json");
                var types=JsonSerializer.Deserialize<List<ProductType>>(typesData);
                    if(types!=null && types.Any())
                    context.ProductTypes.AddRange(types);
            }
              if (!context.Products.Any())
            {
                var productsData= File.ReadAllText("../Infrastructure/Data/SeedData/JsonFiles/products.json");
                var products=JsonSerializer.Deserialize<List<Product>>(productsData);
                    if(products!=null && products.Any())
                    context.Products.AddRange(products);
            }
                    context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                var logger=loggerFactory.CreateLogger<StoreContextSeed>();
                logger.LogError(ex,"An error accure during seed data");
            }
        }
    }
}