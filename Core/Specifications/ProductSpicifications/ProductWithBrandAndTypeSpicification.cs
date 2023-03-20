using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications.ProductSpicifications
{
    public class ProductWithBrandAndTypeSpicification : BaseSpecification<Product>
    {
        public ProductWithBrandAndTypeSpicification( )
        {
            AddInclude(x=>x.ProductBrand);
            AddInclude(x=>x.ProductType);
        }
        public ProductWithBrandAndTypeSpicification(int id):base(x=>x.Id==id)
        {
             AddInclude(x=>x.ProductBrand);
             AddInclude(x=>x.ProductType);
        }
    }
}