using Core.Common;
using Core.Entities;
using System;

namespace Core.Events
{
    public class ProductCreatedEvent : IDomainEvent
    {
        public ProductCreatedEvent(Product product)
        {
            Product = product;
        }

        public Product Product { get; }
        DateTimeOffset IDomainEvent.DateOccurred { get; set; } = new DateTimeOffset();
     }
}
