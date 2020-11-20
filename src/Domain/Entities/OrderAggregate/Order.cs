using Domain.Common;
using Domain.Interfaces;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities.OrderAggregate
{
    public class Order : AuditableEntity, IAggregateRoot
    {
        public Order()
        {
        }

        public Order(
            IReadOnlyList<OrderItem> orderItems, 
            string buyerEmail,
            ShipToAddress shipToAddress,
            DeliveryMethod deliveryMethod, 
            string paymentIntentId)
        {
            OrderItems = orderItems;
            BuyerEmail = buyerEmail;
            ShipToAddress = shipToAddress;
            DeliveryMethod = deliveryMethod;
            PaymentIntentId = paymentIntentId;
        }

        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public ShipToAddress ShipToAddress { get; set; }
        public DeliveryMethod DeliveryMethod { get; set; }
        public IReadOnlyList<OrderItem> OrderItems { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public string PaymentIntentId { get; set; }


        public decimal SubTotal()
        {
            var subtotal = 0m;
            foreach (var item in OrderItems)
            {
                subtotal += item.Price * item.Quantity;
            }
            return subtotal;
        }

        public decimal GetTotal()
        {
            return SubTotal() + DeliveryMethod.Price;
        }
    }
}
