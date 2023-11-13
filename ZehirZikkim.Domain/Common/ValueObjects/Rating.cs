using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Common.ValueObjects;

public sealed class Rating : ValueObject
{   

    public double Value { get; }

    private Rating(double rate) {
        Value = rate;
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }

    public static Rating CreateNew(double rating = 0) => new(rating);
}