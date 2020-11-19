using Core.Common;
using System.Collections.Generic;

namespace Core.ValueObjects
{
    public class ProductItem : ValueObject
    {
        public ProductItem()
        {
        }

        public ProductItem(int productItemId, string productName, string pictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PictureUrl = pictureUrl;
        }

        public int ProductItemId { get; private set; }
        public string ProductName { get; private set; }
        public string PictureUrl { get; private set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return ProductItemId;
            yield return ProductName;
            yield return PictureUrl;
        }
    }
}
