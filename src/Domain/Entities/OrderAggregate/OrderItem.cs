using Domain.Common;
using Domain.ValueObjects;

namespace Domain.Entities.OrderAggregate
{
    public class OrderItem : AuditableEntity
    {
        public OrderItem()
        {
        }

        public OrderItem(ProductItem itemOrdered, decimal price, int quantity)
        {
            ItemOrdered = itemOrdered;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public ProductItem ItemOrdered { get; private set; }
        public decimal Price { get; private set; }
        public int Quantity { get; private set; }
    }
}
