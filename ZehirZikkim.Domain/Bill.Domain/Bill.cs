using ZehirZikkim.Domain.Bill.Domain.ValueObjects;
using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.Domain.ValueObjects;
using ZehirZikkim.Domain.Guest.Domain.ValueObjects;
using ZehirZikkim.Domain.Host.Domain.ValueObjects;

namespace ZehirZikkim.Domain.Bill.Domain;

public sealed class Bill : AggregateRoot<BillId> {

    public DinnerId DinnerId { get; }

    public GuestId GuestId { get; }

    public HostId HostId { get; }

    public Price Price { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    private Bill(
        BillId id, DinnerId dinnerId, GuestId guestId,
        HostId hostId, Price price,
        DateTime createdAt, DateTime updatedAt ) : base(id) {

        DinnerId = dinnerId;
        GuestId = guestId;
        HostId = hostId;
        Price = price;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }


    public static Bill Create(
        DinnerId dinnerId, GuestId guestId, 
        HostId hostId, Price price) => new( BillId.CreateUnique(), dinnerId, guestId, 
            hostId, price, DateTime.UtcNow, DateTime.UtcNow);
}