using ZehirZikkim.Application.Common.Interfaces.Persistence;
using ZehirZikkim.Domain.MenuAggregate;

namespace ZehirZikkim.Infrastructure.Persistence.Memory.Repositories;


public class MenuRepository: IMenuRepository {

    private static readonly List<Menu> menus = new();
    public void Add(Menu menu) {
        menus.Add(menu);
    }
}