using Core.Common;
using Core.Entities;
using System.Collections.Generic;

namespace Core.ValueObjects
{
    public class ShipToAddress : ValueObject
    {
        public ShipToAddress() 
        { 
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
            yield return Street;
            yield return City;
            yield return State;
            yield return Zipcode;
        }
    }
}
