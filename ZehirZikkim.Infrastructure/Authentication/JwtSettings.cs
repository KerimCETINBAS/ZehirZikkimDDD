namespace ZehirZikkim.Infrastructure.Authentication;


 public class Access  {
        public required string  Secret { get; init; }
        public required string Issuer { get; init; }
        public string? Audience { get; init; } 

        public required int ExpiryMinutes { get; init; }
} 

public class JwtSettings {
    public const string SectionName = "JwtSettings";
    public Access Access {get; init;} = null!;
    
}