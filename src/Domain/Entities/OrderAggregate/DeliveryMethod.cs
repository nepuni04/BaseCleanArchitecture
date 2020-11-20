﻿using Domain.Common;

namespace Domain.Entities.OrderAggregate
{
    public class DeliveryMethod : AuditableEntity
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string DeliveryTime { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}