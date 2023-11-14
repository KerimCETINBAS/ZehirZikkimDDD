using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Host.Domain.ValueObjects;

public sealed class HostId: ValueObject {
    public Guid Value { get; }

    private HostId(Guid value) {
        Value = value;
    }

    public static HostId CreateUnique() => new(Guid.NewGuid());

    public static HostId Create(string id) => new(new Guid(id));
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Value;
    }
}