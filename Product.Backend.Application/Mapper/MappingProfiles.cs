using AutoMapper;
using Product.Backend.Application.Product;
using Product.Backend.Domain;

namespace Product.Backend.Application.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductEntity, ProductDto>().ReverseMap();
        }
    }
}
