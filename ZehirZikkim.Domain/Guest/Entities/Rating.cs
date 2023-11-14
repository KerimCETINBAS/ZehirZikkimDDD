using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Guest.ValueObjects;
using ZehirZikkim.Domain.Host.ValueObjects;

namespace ZehirZikkim.Domain.Guest.Entities;

public sealed class GuestRating : Entity<GuestRatingId> {

    public HostId HostId { get; }
    
    
    public DinnerId DinnerId { get; }


    public Rating Rating { get; }
    

    public DateTime CreatedAt { get; }


    public DateTime UpdatedAt { get; } 

    
    private GuestRating(
        GuestRatingId id, HostId hostId, DinnerId dinnerId,
        Rating rating, DateTime createdAt, DateTime updatedAt) : base(id) {
            
            HostId = hostId;
            DinnerId = dinnerId;
            Rating = rating;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
    }

    public static GuestRating Create(
        HostId hostId, DinnerId dinnerId, Rating rating,
        DateTime createdAt, DateTime updatedAt
    ) => new(  
        GuestRatingId.CreateUnique(), 
        hostId, dinnerId, rating, createdAt, updatedAt);
}