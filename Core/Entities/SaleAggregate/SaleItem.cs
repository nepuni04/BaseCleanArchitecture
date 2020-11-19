using Core.Common;
using Core.ValueObjects;

namespace Core.Entities.SaleAggregate
{
    public class SaleItem : AuditableEntity
    {
        public SaleItem()
        {
        }

        public SaleItem(ProductItem itemSold, decimal price, int quantity)
        {
            ItemSold = itemSold;
            Price = price;
            Quantity = quantity;
        }

        public int Id { get; set; }
        public ProductItem ItemSold { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}