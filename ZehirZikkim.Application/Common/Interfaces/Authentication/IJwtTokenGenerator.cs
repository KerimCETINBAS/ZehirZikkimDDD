using ZehirZikkim.Domain.User.Domain;

namespace ZehirZikkim.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator {
    string GenerateToken(User user);
}

