using Domain.Common;
using Domain.Interfaces;
using System;
using System.Collections.Generic;

namespace Domain.Entities.SaleAggregate
{
    public class Sale : AuditableEntity, IAggregateRoot
    {
        public Sale() { }
        public Sale(IReadOnlyList<SaleItem> saleItems, Customer customer, PaymentType paymentType)
        {
            SaleItems = saleItems;
            Customer = customer;
        }

        public int Id { get; set; }
        public DateTimeOffset SaleDate { get; private set; } = DateTimeOffset.Now;
        public IReadOnlyList<SaleItem> SaleItems { get; private set; }
        public PaymentType PaymentType{ get; private set; }
        public Customer Customer { get; private set; }
    }
}
