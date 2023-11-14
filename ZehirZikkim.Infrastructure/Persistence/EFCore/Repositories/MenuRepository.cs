using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.MenuAggregate;
using ZehirZikkim.Infrastructure.Persistence.EFCore.Common;

namespace ZehirZikkim.Infrastructure.Persistence.EFCore.Repositories;


public class MenuRepository: IMenuRepository {

    private readonly ZehirZikkimDbContext dbContext;

    public MenuRepository(ZehirZikkimDbContext dbContext)
    {
        this.dbContext = dbContext;
    }


    public void Add(Menu menu) {
       dbContext.Add(menu);
       dbContext.SaveChanges();
    }
}