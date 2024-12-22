using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;
using Ordering.Infrastructure.Data.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
       .AddApplicationSerivces(builder.Configuration)
       .AddInfrastructureSerivces(builder.Configuration)
       .AddApiSerivces(builder.Configuration);

var app = builder.Build();

app.UseApiSerivces();

if(app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.Run();
