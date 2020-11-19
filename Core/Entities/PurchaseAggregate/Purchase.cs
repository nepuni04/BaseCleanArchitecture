using Core.Common;
using Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Core.Entities.PurchaseAggregate
{
    public class Purchase : AuditableEntity, IAggregateRoot
    {
        public Purchase()
        {
        }

        public Purchase(IReadOnlyList<PurchaseItem> purchaseItems, Supplier supplier)
        {
            PurchaseItems = purchaseItems;
            Supplier = supplier;
        }

        public int Id { get; set; }
        public DateTimeOffset PurchaseDate { get; set; } = DateTimeOffset.Now;
        public IReadOnlyList<PurchaseItem> PurchaseItems { get; set; }
        public Supplier Supplier { get; set; }

        public decimal Total()
        {
            var total = 0m;
            foreach (var item in PurchaseItems)
            {
                total += item.Price * item.Quantity;
            }
            return total;
        }
    }
}
