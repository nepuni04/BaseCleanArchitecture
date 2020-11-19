using Core.Common;
using Core.ValueObjects;

namespace Core.Entities
{
    public class Supplier : AuditableEntity
    {
        public Supplier()
        {
        }

        public Supplier(
            string supplierName,
            string phoneNo, 
            string alternatePhoneNo, 
            string email,
            SupplierAddress address)
        {
            SupplierName = supplierName;
            PhoneNo = phoneNo;
            AlternatePhoneNo = alternatePhoneNo;
            Email = email;
            Address = address;
        }

        public int Id { get; set; }
        public string SupplierName { get; private set; }
        public string PhoneNo { get; private set; }
        public string AlternatePhoneNo { get; private set; }
        public string Email { get; private set; }
        public SupplierAddress Address { get; private set; }
    }
}
