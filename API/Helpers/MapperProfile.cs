using API.Dtos;
using AutoMapper;
using Core.Entities;

namespace API.Helpers
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Product,ProductToReturnDto>()
            .ForMember(dest=>dest.ProductBrand,src=>src.MapFrom(x=>x.ProductBrand.Name))
            .ForMember(dest=>dest.ProductType,src=>src.MapFrom(x=>x.ProductType.Name))
            .ForMember(dest=>dest.PictureUrl,src=>src.MapFrom<ProductUrlResolver>());

        }
    }
}