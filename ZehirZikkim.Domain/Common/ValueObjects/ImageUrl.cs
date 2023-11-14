using ZehirZikkim.Domain.Common.Models;

namespace ZehirZikkim.Domain.Common.ValueObjects;

public sealed class ImageUrl : ValueObject {

    public string Src { get; }

    public string Alt { get; }

    private ImageUrl(string src, string alt) {
        Src = src;
        Alt = alt;
    }

    public static ImageUrl Create(string src, string alt ) => new(src, alt);
    public override IEnumerable<object> GetEqualityComponents() {
        yield return Src;
        yield return Alt;
    }
}