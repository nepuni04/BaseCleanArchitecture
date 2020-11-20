using Domain.Common;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class SupplierAddress : ValueObject
    {
        public SupplierAddress()
        {
        }

        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Street;
            yield return City;
            yield return State;
            yield return Zipcode;
        }
    }
}
