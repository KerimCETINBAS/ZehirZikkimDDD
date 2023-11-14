using ErrorOr;

using MediatR;

using ZehirZikkim.Application.Common.Interfaces.Persistence;

using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.Host.Domain.ValueObjects;

using ZehirZikkim.Domain.MenuAggregate;
using ZehirZikkim.Domain.MenuAggregate.Entities;

namespace ZehirZikkim.Application.Menus.Commands;


public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, ErrorOr<Menu>>
{

    private readonly IMenuRepository menuRepository;

    public CreateMenuCommandHandler(IMenuRepository menuRepository)
    {
        this.menuRepository = menuRepository;
    }


    public async Task<ErrorOr<Menu>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // create menu,
        var menu = Menu.Create(
            
            request.Name,
            request.Description,
            AverageRating.CreateNew(),
            HostId.Create(request.HostId),
            
            request.Items.ConvertAll(menuSection => MenuSection.Create(
                menuSection.Name,
                menuSection.Description,
                menuSection.Items.ConvertAll( item => MenuItem.Create(
                    item.Name,
                    item.Description
                    
                ))
            ))
        );

        // persist menu
        menuRepository.Add(menu);
        // return menu
        return menu;
    }

}