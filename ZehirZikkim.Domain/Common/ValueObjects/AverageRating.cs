using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Common.ValueObjects;

public sealed class AverageRating : ValueObject {   
    public double Value { get; private set; } 
    public int NumOfTotalRates { get; private set; }

    private AverageRating(double rating, int total) {
        Value = rating;
        NumOfTotalRates = total;
    }
    public static AverageRating CreateNew(double ratinng = 0, int numOfTotalRates = 0) {
        return new(ratinng, numOfTotalRates);
    }

    public void AddRating(Rating rating) {
        Value = (Value + NumOfTotalRates + rating.Value) / ++NumOfTotalRates;
    }
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
        yield return NumOfTotalRates;
    }
}