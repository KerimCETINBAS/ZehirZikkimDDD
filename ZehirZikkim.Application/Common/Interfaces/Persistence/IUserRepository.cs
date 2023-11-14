using ZehirZikkim.Domain.Entities;

namespace ZehirZikkim.Application.Common.Interfaces.Persistence;

public interface IUserRepository {
    User? GetUserByEmail(string email);
    void Add(User user);
}