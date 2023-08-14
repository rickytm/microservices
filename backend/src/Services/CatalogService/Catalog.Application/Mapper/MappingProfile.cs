using AutoMapper;
using Catalog.Application.Responses;
using Catalog.Core;
using System;

namespace Catalog.Application.Mapper;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Core.Attribute, AttributeDto>();

        CreateMap<Brand, BrandDto>();

        CreateMap<Category, CategoryDto>()
            .ForMember(r => r.ParentName, z => z.MapFrom(a => a.Parent!.Nombre))
            .ForMember(r => r.AttributesGrouped, opt => opt.Ignore());
        
        CreateMap<Product, ProductDto>()
            .ForMember(p => p.CategoryNombre, x => x.MapFrom(a => a.Category!.Nombre))
            .ForMember(p => p.BrandNombre, x => x.MapFrom(a => a.Brand!.Nombre));

        CreateMap<ProductAttribute, ProductAttributeDto>()
            .ForMember(p => p.ProductName, x => x.MapFrom(a => a.Product!.Nombre))
            .ForMember(p => p.CategoryName, x => x.MapFrom(a => a.Category!.Nombre))
            .ForMember(p => p.Key, x => x.MapFrom(a => a.Attribute!.Key))
            .ForMember(p => p.Value, x => x.MapFrom(a => a.Attribute!.Value));

        CreateMap<ProductVariant, ProductVariantDto>();

        CreateMap<Variant, VariantDto>();

    }
}
