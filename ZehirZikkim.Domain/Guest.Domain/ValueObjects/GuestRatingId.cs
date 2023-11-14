using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Guest.Domain.ValueObjects;

public sealed class GuestRatingId : ValueObject
{
    public Guid Value { get; }

    private GuestRatingId(Guid value) {
        Value = value;
    }

    public static GuestRatingId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}