
using EShopBE;
using EShopBE.Domain;
using EShopBE.Graphql;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddGraphQLServer().AddGraphqlService(services);

services.AddProgramInstaller(builder.Configuration);
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(static endpoints =>
{
    _ = endpoints.MapGraphQL();
}
);

app.SeedData();
app.Run();
