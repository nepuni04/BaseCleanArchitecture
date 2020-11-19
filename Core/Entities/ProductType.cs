using Core.Common;

namespace Core.Entities
{
    public class ProductType : AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}