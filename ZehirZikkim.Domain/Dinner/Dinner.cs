using ZehirZikkim.Domain.Common.Enums;
using ZehirZikkim.Domain.Common.Models;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Dinner.Entities;
using ZehirZikkim.Domain.Dinner.ValueObjects;
using ZehirZikkim.Domain.Host.ValueObjects;
using ZehirZikkim.Domain.Menu.ValueObjects;

namespace ZehirZikkim.Domain.Dinner;

public sealed class Dinner : AggregateRoot<DinnerId> {
    
    public string Name { get; }

    public string Description { get; }

    public DateTime StartDateTime { get; }

    public DateTime EndDateTime { get; }

    public DinnerStatus DinnerStatus { get; }

    public Price Price { get; }
    
    public HostId HostId { get; }

    public MenuId MenuId { get; }

    public ImageUrl ImageUrl { get; }

    public Location Location { get; }

    #region reservations
    private readonly List<Reservation> reservations = new();
    public IReadOnlyList<Reservation> Reservations => reservations.AsReadOnly();
    #endregion /reservations
    
    public DateTime CreatedAt { get; }

    public DateTime UpdatedAt { get; }

    private Dinner(
        DinnerId id, string name, string description,
        DateTime startDateTime, DateTime endDateTime, 
        DinnerStatus dinnerStatus, Price price, HostId hostId,
        MenuId menuId, ImageUrl imageUrl, Location location,
        DateTime createdAt, DateTime updatedAt ) : base(id) {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            DinnerStatus = dinnerStatus;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
    }

    public static Dinner Create(
        string name,string description, 
        DateTime startDateTime,DateTime endDateTime,
        DinnerStatus dinnerStatus, Price price, HostId hostId,
        MenuId menuId, ImageUrl imageUrl, Location location) => new(
            
            DinnerId.CreateUnique(), name, description, startDateTime,
            endDateTime, dinnerStatus, price, hostId,
            menuId, imageUrl, location, 
            DateTime.UtcNow, DateTime.UtcNow
        );
}