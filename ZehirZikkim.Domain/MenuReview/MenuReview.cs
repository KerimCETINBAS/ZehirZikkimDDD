using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Guest.ValueObjects;
using ZehirZikkim.Domain.Host.ValueObjects;
using ZehirZikkim.Domain.Menu.ValueObjects;
using ZehirZikkim.Domain.MenuReview.ValueObjects;

namespace ZehirZikkim.Domain.MenuReview;

public sealed class MenuReview : AggregateRoot<MenuReviewId>
{

    public Rating Rating { get; }

    public string Comment { get; }

    public HostId HostId { get; }

    public MenuId MenuId { get; }

    public GuestId GuestId { get; }

    public DinnerId DinnerId { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }
    
    private MenuReview(
        MenuReviewId id, Rating rating, string comment,
        HostId hostId, MenuId menuId, GuestId guestId, DinnerId dinnerId,
        DateTime createdAt, DateTime updatedAt) : base(id) {
            
        Rating    = rating;
        Comment   = comment;
        HostId    = hostId;
        MenuId    = menuId;
        GuestId   = guestId;
        DinnerId  = dinnerId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static MenuReview Create(
        Rating rating, string comment, HostId hostId, MenuId menuId,
        GuestId guestId,  DinnerId dinnerId
    ) => new( 
        MenuReviewId.CreateUnique(), rating, comment, hostId,
        menuId,  guestId, dinnerId, 
        DateTime.UtcNow, DateTime.UtcNow
    );
}