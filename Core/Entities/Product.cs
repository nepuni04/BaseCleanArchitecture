using Core.Common;
using System.Collections.Generic;

namespace Core.Entities
{
    public class Product : AuditableEntity, IHasDomainEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; }

        public List<IDomainEvent> DomainEvents { get; set; } = new List<IDomainEvent>();
    }
}
