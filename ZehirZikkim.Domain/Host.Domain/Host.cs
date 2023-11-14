using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.Domain.ValueObjects;
using ZehirZikkim.Domain.Host.Domain.ValueObjects;
using ZehirZikkim.Domain.MenuAggregate.ValueObjects;
using ZehirZikkim.Domain.User.Domain.ValueObjects;

namespace ZehirZikkim.Domain.Host.Domain;

public sealed class Host : AggregateRoot<HostId> {
    
    public string FirstName { get; }


    public string LastName { get; }


    public ImageUrl ProfileImage { get; }


    public AverageRating AverageRating { get; }

    
    public UserId UserId { get; }


    #region menuIds 
    private readonly List<MenuId> menuIds = new();
    public IReadOnlyList<MenuId> MenuIds => menuIds.AsReadOnly();
    #endregion /menuIds


    #region dinnerIds 
    private readonly List<DinnerId> dinnerIds = new();
    public IReadOnlyList<DinnerId> DinnerIds => dinnerIds.AsReadOnly();
    #endregion /dinnerIds


    public DateTime CreatedAt { get; }


    public DateTime UpdatedAt { get; }
    
    private Host(
        HostId id,  string firstName, string lastName, ImageUrl profileImage,
        AverageRating averageRating, UserId userId, 
        DateTime createdAt, DateTime updatedAt) : base(id) {
        
        FirstName = firstName;
        LastName = lastName;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Host Create(
        string firstName, string lastName, ImageUrl profileImage,
        AverageRating averageRating, UserId userId ) => new(
            
            HostId.CreateUnique(), firstName, lastName, profileImage,
            averageRating, userId,
            DateTime.UtcNow, DateTime.UtcNow
        );
}