using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

using ZehirZikkim.Domain.MenuAggregate;

using ZehirZikkim.Domain.MenuAggregate.ValueObjects;

namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Models;

[Table("Menu")]
public class MenuModel: BaseModel {


    [MaxLength(200)]
    public required string Name { get; set; }

    [Key, Column(Order = 1)]

    public required Guid MenuSectionId { get; set ;}

    public required string Description { get; set; }
    public AverageRatingModel? AverageRating { get; set; }

    public ICollection<MenuSectionModel> MenuSections { get; set; } = new List<MenuSectionModel>();
    public ICollection<Dinner> MenuSectionsModel { get; set; } = new List<Dinner>();
}


[Owned]
public class AverageRatingModel {
    public double Value { get; set; }
    public uint NumOfTotalRates { get; set; }
    public Guid HostId { get; set; }

    public DateTime UpdatedAt { get; set; }
    public DateTime CreatedAt { get; set; }

    
    public ICollection<MenuSectionModel> Sections { get; set; }  = new List<MenuSectionModel>();
    
}

[Table("MenuSection")]
public class MenuSectionModel {
    
    [Key]
    public Guid Id { get; set; }

    [MaxLength(200)]
    public required string Name { get; set; }

    public required Guid MenuId { get; set; }

    public Menu? Menu { get; set; }

}


public class MenuSectionItemModel {
    [Key]
    public Guid Id { get; set; }

    public required Guid MenuSectionId { get; set; }

    public MenuSectionModel? MenuSection { get; set; }
}