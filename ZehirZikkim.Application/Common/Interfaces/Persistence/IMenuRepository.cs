using ZehirZikkim.Domain.MenuAggregate;

namespace ZehirZikkim.Application.Common.Interfaces.Persistence;


public interface IMenuRepository {
    void Add(Menu menu);
}