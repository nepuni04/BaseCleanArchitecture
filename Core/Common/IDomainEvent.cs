using System;
using System.Collections.Generic;

namespace Core.Common
{
    public interface IHasDomainEvent
    {
        public List<IDomainEvent> DomainEvents { get; set; }
    }

    public interface IDomainEvent
    {
        public DateTimeOffset DateOccurred { get; protected set; }
    }
}
