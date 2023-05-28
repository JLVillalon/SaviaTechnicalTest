using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.ViewModels;
using AutoMapper;
using Domain;

namespace Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CreateProductCommand, Product>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
