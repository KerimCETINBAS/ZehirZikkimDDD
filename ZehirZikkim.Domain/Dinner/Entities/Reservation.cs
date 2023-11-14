using ZehirZikkim.Domain.Bill.ValueObjects;
using ZehirZikkim.Domain.Common.Enums;
using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Guest.ValueObjects;

namespace ZehirZikkim.Domain.Dinner.Entities;

public sealed class Reservation : Entity<ReservationId>
{   
    
    public uint GuestCount { get; }

    public ReservationStatus Status { get; }

    public GuestId GuestId { get; }

    public BillId BillId { get; }

    public DateTime ArrivalDateTime { get; }

    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }
    
    private Reservation(
        ReservationId id, uint guestCount, 
        ReservationStatus reservationStatus,
        GuestId guestId, BillId billId,
        DateTime arrivalDateTime,
        DateTime createdAt, DateTime updatedAt) : base(id)
    {
        GuestCount = guestCount;
        Status = reservationStatus;
        GuestId = guestId;
        BillId = billId;
        ArrivalDateTime = arrivalDateTime;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;

    }   

    public static Reservation Create(uint guestCount, ReservationStatus status,
    GuestId guestId, BillId billId, DateTime arrivalDateTime) => new(
        ReservationId.CreateUnique(),
        guestCount, status, guestId,
        billId, arrivalDateTime,
        DateTime.UtcNow, DateTime.UtcNow);
}