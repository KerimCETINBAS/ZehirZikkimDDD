using Microsoft.EntityFrameworkCore;

using ZehirZikkim.Infrastructure.Persistence.EFCore.Models;

namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Common;

public class ZehirZikkimDbContext: DbContext {

    public ZehirZikkimDbContext(DbContextOptions<ZehirZikkimDbContext> options): base(options) {  }

    public  DbSet<MenuModel> Menus { get; set; }

    public  DbSet<MenuSectionModel> MenuSection { get; set; }

    public  DbSet<Dinner> Dinner { get; set; }

    public  DbSet<MenuSectionItemModel> MenuSectionItem { get; set; }

    public  DbSet <ReservationModel> Reservation { get; set; }
}