using ZehirZikkim.Domain.Bill.ValueObjects;
using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Guest.Entities;
using ZehirZikkim.Domain.Guest.ValueObjects;
using ZehirZikkim.Domain.MenuReview.ValueObjects;
using ZehirZikkim.Domain.User.ValueObjects;

namespace ZehirZikkim.Domain.Guest;

public sealed class Guest : AggregateRoot<GuestId> {
    
    public string FirstName { get; }


    public string LastName { get; }


    public ImageUrl ProfileImage { get; }


    public AverageRating AverageRating { get; }


    public UserId UserId { get; }


    #region UpcomingDinnerIds
    private readonly List<DinnerId> upcomingDinnerIds = new();
    public IReadOnlyList<DinnerId> UpcomingDinnerIds => upcomingDinnerIds.AsReadOnly();
    #endregion /upcomingDinnerIds


    #region pastDinnerIds 
    private readonly List<DinnerId> pastDinnerIds = new();
    public IReadOnlyList<DinnerId> PastDinnerIds => pastDinnerIds.AsReadOnly();
    #endregion /pastDinnerIds


    #region pendingDinnerIds
    private readonly List<DinnerId> pendingDinnerIds = new();
    public IReadOnlyList<DinnerId> PendingDinnerIds => pendingDinnerIds.AsReadOnly();
    #endregion /pendingDinnerIds


    #region billIds
    private readonly List<BillId> billIds = new();
    public IReadOnlyList<BillId> BillIds => billIds.AsReadOnly();
    #endregion /billIds 


    #region  menuReviewIds
    private readonly List<MenuReviewId> menuReviewIds = new();
    public IReadOnlyList<MenuReviewId> MenuIds => menuReviewIds.AsReadOnly();
    #endregion /menuReviewIds

    
    #region  ratings 
    private readonly List<GuestRating> guestRatings = new();
    public IReadOnlyList<GuestRating> GuestRatings => guestRatings.AsReadOnly();
    #endregion /ratings


    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }


    private Guest(
        GuestId id, string firstName, string lastname, ImageUrl profileImage,
        AverageRating averageRating, UserId userId, 
        DateTime createdAt, DateTime updatedAt) : base(id) {
            
        FirstName = firstName;
        LastName = lastname;
        ProfileImage = profileImage;
        AverageRating = averageRating;
        UserId = userId;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public static Guest Create(
        string firstName, string lastname, ImageUrl profileImage,
        AverageRating averageRating, UserId userId
    ) => new(

        GuestId.CreateUnique(), firstName, lastname, 
        profileImage, averageRating, userId, DateTime.UtcNow, DateTime.UtcNow);
}