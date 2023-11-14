using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.User.Domain;

namespace ZehirZikkim.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{

    private static List<User> _users = new();
    public void Add(User user)
    {
        _users.Add(user);
    }

    public User? GetUserByEmail(string email)
    {

        return _users.SingleOrDefault( u => u.Email == email);
    }
}