using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Dinner.Domain.ValueObjects;

public sealed class ReservationId : ValueObject {
    
    public Guid Value { get; }

    private ReservationId(Guid value) {
        Value = value;
    }

    public static ReservationId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}