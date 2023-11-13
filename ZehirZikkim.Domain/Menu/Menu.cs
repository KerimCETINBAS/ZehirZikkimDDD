using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Host.ValueObjects;
using ZehirZikkim.Domain.Menu.Entities;
using ZehirZikkim.Domain.Menu.ValueObjects;
using ZehirZikkim.Domain.MenuReview.ValueObjects;

namespace ZehirZikkim.Domain.Menu;


public sealed class Menu : AggregateRoot<MenuId> {

    #region sections    
    private readonly List<MenuSection> sections = new();
    IReadOnlyList<MenuSection> Sections => sections;
    #endregion /sections
   
    public string Name { get; }

    public string Description { get; }

    public AverageRating AverageRating { get; }

    public DateTime CreatedAt { get; }
    
    public DateTime UpdatedAt { get; }

    public HostId HostId { get; }

    #region dinnerId
    private readonly List<DinnerId> dinnerIds = new();
    public IReadOnlyList<DinnerId> DinnerIds  => dinnerIds;
    #endregion /dinenrid
        
    # region menuReviewIds
    private readonly List<MenuReviewId> menuReviewIds = new();
    public IReadOnlyList<MenuReviewId> MenuReviewIds => menuReviewIds;
    # endregion /menuReviewIds
   
    private Menu(
        MenuId menuId,
        string name,
        string description,
        AverageRating averageRating,
        DateTime createdAt,
        DateTime updatedAt,
        HostId hostId): base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating  = averageRating;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        HostId = hostId;
    }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId
    ) {
        return new(MenuId.CreateUnique(), name, description, averageRating, DateTime.UtcNow, DateTime.UtcNow, hostId);
    }   
}