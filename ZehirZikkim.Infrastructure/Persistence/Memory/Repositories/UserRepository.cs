using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.User.Domain;

namespace ZehirZikkim.Infrastructure.Persistence.Memory.Repositories;

public class UserRepository : IUserRepository
{

    private static readonly List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {

        return _users.SingleOrDefault( u => u.Email == email);
    }
}