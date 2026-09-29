using AutoMapper;
using eCommerce.Core.Domain.Entities;
using eCommerce.Core.DTO;

namespace eCommerce.Core.Mappers;

public class ProductMappingProfile : Profile
{
    public ProductMappingProfile()
    {
        CreateMap<ProductDTO, Product>();
    }
}
