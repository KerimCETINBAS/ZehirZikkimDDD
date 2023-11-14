using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Common.ValueObjects;



public class Price: ValueObject {
    public decimal Ammount {get; private set; }
    public string Currency { get; private set; }


    public Price(decimal amount, string currency) {
        Ammount = amount;
        Currency = currency;
    } 

    public override IEnumerable<object> GetEqualityComponents() {
        yield return Ammount;
        yield return Currency;
    }
}