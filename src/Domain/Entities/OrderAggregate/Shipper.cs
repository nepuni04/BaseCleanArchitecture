using Domain.Common;

namespace Domain.Entities.OrderAggregate
{
    public class Shipper : AuditableEntity
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string  PhoneNo { get; set; }
    }
}
