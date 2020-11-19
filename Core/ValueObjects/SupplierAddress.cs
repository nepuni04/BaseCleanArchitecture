using Core.Common;
using Core.Entities;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Core.ValueObjects
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
