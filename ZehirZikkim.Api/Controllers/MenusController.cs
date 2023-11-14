using ErrorOr;

using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZehirZikkim.Application.Menus.Commands;
using ZehirZikkim.Contracts.Menus;

namespace ZehirZikkim.Api.Controllers;

[Route("hosts/{hostId}/menus")]
public class MenusController: ApiController {
    private readonly IMapper mapper;
    private readonly ISender mediator;

    public MenusController(IMapper mapper, ISender mediator)
    {
        this.mapper = mapper;
        this.mediator = mediator;

    }


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateMenu(
        CreateMenuRequest request,
        string hostId
    ) {
        CreateMenuCommand command = mapper.Map<CreateMenuCommand>((request, hostId));

        var menuResult = await mediator.Send(command);
        
        return menuResult.Match(
            menu => Ok(mapper.Map<MenuResponse>(menu)),
            errors => Problem(errors)
        );

    }
}