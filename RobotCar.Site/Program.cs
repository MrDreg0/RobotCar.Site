using Microsoft.Extensions.Options;
using Refit;
using RobotCar.Site;
using RobotCar.Site.Components;
using RobotCar.Site.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
  .AddInteractiveServerComponents();

builder.Services.AddBlazorBootstrap();

builder.Services
  .AddOptions()
  .Configure<RobotApiOptions>(builder.Configuration.GetSection("RobotApi"));

builder.Services
  .AddRefitClient<IRobotCarApi>()
  .ConfigureHttpClient((serviceProvider, client) => 
    client.BaseAddress = new Uri(serviceProvider.GetService<IOptions<RobotApiOptions>>()!.Value.BaseUrl));


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
  app.UseExceptionHandler("/Error", createScopeForErrors: true);
  app.UseHsts();
  app.UseHttpsRedirection();
}

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
  .AddInteractiveServerRenderMode();

app.Run();
