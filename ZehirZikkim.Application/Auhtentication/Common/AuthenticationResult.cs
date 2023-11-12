using ZehirZikkim.Domain.Entities;

namespace ZehirZikkim.Application.Authentication.Common;


public record AuthenticationResult(
    User User,
    string Token);