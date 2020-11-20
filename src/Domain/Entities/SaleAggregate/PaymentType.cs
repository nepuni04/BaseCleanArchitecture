using System.Runtime.Serialization;

namespace Domain.Entities.SaleAggregate
{
    public enum PaymentType
    {
        [EnumMember(Value = "Cash Payment")]
        cash,

        [EnumMember(Value = "Card Payment")]
        card,

        [EnumMember(Value = "Bank Transfer")]
        banck,
    }
}