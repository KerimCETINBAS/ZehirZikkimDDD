using Mapster;
using ZehirZikkim.Application.Auhtentication.Commands.Register;
using ZehirZikkim.Application.Auhtentication.Queries.Login;
using ZehirZikkim.Application.Authentication.Common;
using ZehirZikkim.Contracts.Authentication;

namespace ZehirZikkim.Api.Common.Mapping;


public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}