using ZehirZikkim.Domain.Entities;

namespace ZehirZikkim.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator {
    string GenerateToken(User user);
}

