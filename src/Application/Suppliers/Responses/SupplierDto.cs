using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Suppliers.Responses
{
    public class SupplierDto : IMapFrom<Supplier>
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public string PhoneNo { get; set; }
        public string AlternatePhoneNo { get; set; }
        public string Email { get; set; }
        public SupplierAddress Address { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Supplier, SupplierDto>();
        }
    }
}
