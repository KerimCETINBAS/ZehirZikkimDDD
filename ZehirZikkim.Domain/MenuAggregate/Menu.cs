using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.Domain.ValueObjects;
using ZehirZikkim.Domain.Host.Domain.ValueObjects;
using ZehirZikkim.Domain.MenuAggregate.Entities;
using ZehirZikkim.Domain.MenuAggregate.ValueObjects;
using ZehirZikkim.Domain.MenuReview.Domain.ValueObjects;

namespace ZehirZikkim.Domain.MenuAggregate;


public sealed class Menu : AggregateRoot<MenuId> {

    #region sections    
    private readonly List<MenuSection> sections = new();
    public IReadOnlyList<MenuSection> Sections => sections;
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
        HostId hostId,
        List<MenuSection> _sections ): base(menuId)
    {
        Name = name;
        Description = description;
        AverageRating  = averageRating;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        HostId = hostId;
        sections = _sections;
    }

    public static Menu Create(
        string name,
        string description,
        AverageRating averageRating,
        HostId hostId,
        List<MenuSection> sections
    ) {
        return new(MenuId.CreateUnique(), name, description, averageRating, DateTime.UtcNow, DateTime.UtcNow, hostId, sections);
    }   
}