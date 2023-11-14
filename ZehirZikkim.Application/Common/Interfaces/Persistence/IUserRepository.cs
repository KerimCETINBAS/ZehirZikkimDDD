using ZehirZikkim.Domain.User.Domain;

namespace ZehirZikkim.Application.Common.Interfaces.Persistence;

public interface IUserRepository {
    User? GetUserByEmail(string email);
    void Add(User user);
}