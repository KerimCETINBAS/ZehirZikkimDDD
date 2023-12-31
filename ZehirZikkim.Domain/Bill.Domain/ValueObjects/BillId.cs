using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Bill.Domain.ValueObjects;

public sealed class BillId : ValueObject {
    
    public Guid Value { get; }

    private BillId(Guid value) {
        Value = value;
    }

    public static BillId CreateUnique() => new(Guid.NewGuid());

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
