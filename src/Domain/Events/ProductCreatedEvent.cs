using Domain.Common;
using Domain.Entities;
using System;

namespace Domain.Events
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
