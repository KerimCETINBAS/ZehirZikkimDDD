using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

using ZehirZikkim.Domain.Bill.Domain.ValueObjects;

using ZehirZikkim.Domain.Common.Enums;
namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Models;



[Table("Dinner")]
public class Dinner: BaseModel {
    public required string Name { get; set; }

    public required string Description { get; set; } 

    public required string StartDateTime { get; set; }

    public required DinnerStatus DinnerStatus { get; set; }

    public required DinnerPriceModel Price { get; set; }

    public required Guid HostId { get; set; }

    public required Guid MenuId { get; set; }

    public required ImageUrlModel ImageUrl { get; set; }

    public required LocationModel Location { get; set; }

    public ICollection<ReservationModel> Reservations { get; set; } = new List<ReservationModel>();

}


[Owned]
public class DinnerPriceModel {
    public float Value { get; set; }

    public required string Currency { get; set; }
}

[Owned]
public class LocationModel {
    public required string Name { get; set;  }

    public required string Address { get; set; }

    public double Latitude { get; set; }

    public double Longitude { get; set;  }

}


[Table("Reservation")]
public class ReservationModel: BaseModel {

    
    public required Guid DinnerId { get; set; }
    

    public ReservationStatus ReservationStatus { get; set; }

    public required Guid GetGuid { get; set; }

    public required BillId BillId { get; set; }

    public required DateTime ArrivalDateTime { get; set; }

}