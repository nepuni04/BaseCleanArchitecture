using Application.Common.Mappings;
using AutoMapper;
using Core.Entities;

namespace Application.Products.Responses
{
    public class ProductTypeDto : IMapFrom<ProductType>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ProductType, ProductTypeDto>();
        }
    }
}
