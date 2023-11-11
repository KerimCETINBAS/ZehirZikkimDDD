using Microsoft.AspNetCore.Mvc.Infrastructure;
using ZehirZikkim.Api.Errors;
using ZehirZikkim.Application;
using ZehirZikkim.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddSingleton<ProblemDetailsFactory, ZehirZikkimProblemDetailsFactory>();
}

var app = builder.Build();

{     
    
    app.UseExceptionHandler("/error");
    if (app.Environment.IsDevelopment())
    {   
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    
    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();
    
    app.Run();

}