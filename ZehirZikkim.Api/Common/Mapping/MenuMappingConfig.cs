using Mapster;

using ZehirZikkim.Application.Menus.Commands;
using ZehirZikkim.Contracts.Menus;
using ZehirZikkim.Domain.Common.ValueObjects;
using ZehirZikkim.Domain.MenuAggregate;
using ZehirZikkim.Domain.MenuAggregate.Entities;
using MenuItem = ZehirZikkim.Domain.MenuAggregate.Entities.MenuItem;
using MenuSection = ZehirZikkim.Domain.MenuAggregate.Entities.MenuSection;

namespace ZehirZikkim.Api.Common.Mapping;

public class MenuMappingConfig : IRegister {
    public void Register(TypeAdapterConfig config) {
        
        config.NewConfig<(CreateMenuRequest Request, string HostId), CreateMenuCommand>()
            .Map(dest => dest.HostId, src => src.HostId)
            .Map(dest => dest, src => src.Request);
    
        // config.NewConfig<(CreateMenuRequest Reqeust, string HostId), CreateMenuCommand>()
        //     .Map(dest => dest.HostId, src => src.HostId)
        //     .Map(dest => dest, src => src.Reqeust)
        //     .Map(dest => dest.Items, src => src.Reqeust.Items);



        config.NewConfig<Menu, MenuResponse>()
            .Map( dest => dest.Id, src => src.Id.Value)
            .Map ( dest => dest.AverageRating, src =>  src.AverageRating.Value )
            .Map ( dest => dest.HostId, src => src.HostId.Value)
            .Map ( dest => dest.DinnerIds, src => src.DinnerIds.Select( ids => ids.Value ))
            .Map ( dest => dest.MenuReviewIds, src => src.MenuReviewIds.Select( ids => ids.Value ));

        config.NewConfig<MenuSection, MenuSectionResponse>()
            .Map( dest => dest.Id, src => src.Id.Value);

        config.NewConfig<MenuItem, MenuItemResponse>()
            .Map( dest => dest.Id, src => src.Id.Value);
    }
}