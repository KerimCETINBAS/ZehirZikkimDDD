using System.ComponentModel.DataAnnotations;
using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.User.Domain.ValueObjects;

namespace ZehirZikkim.Domain.User.Domain;

public sealed class User: AggregateRoot<UserId> {

    public string FirstName { get; }


    public string LastName { get; }


    [EmailAddress]
    public string Email { get; }
    
    
    public string Password { get; }


    public DateTime CreatedAt { get; }


    public DateTime UpdatedAt { get; }


    private User(
        UserId id, string firstName, string lastName, string email,
        string password, DateTime createdAt, DateTime updatedAt): base(id) {

        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    } 

    
    public static User Create(
        string firstName, string lastName, string email,
        string password) => new(

            UserId.CreateUnique(), firstName, lastName, email,
            password, DateTime.UtcNow, DateTime.UtcNow);



}

