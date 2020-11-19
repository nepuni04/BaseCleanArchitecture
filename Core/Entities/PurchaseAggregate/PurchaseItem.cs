using Core.Common;
using Core.ValueObjects;

namespace Core.Entities.PurchaseAggregate
{
    public class PurchaseItem : AuditableEntity
    {
        PurchaseItem() { }

        public PurchaseItem(ProductItem itemPurchased, decimal price, int quantity)
        {
            ItemPurchased = itemPurchased;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public ProductItem ItemPurchased { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
