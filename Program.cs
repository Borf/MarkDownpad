using MarkDownPad;
using MarkDownPad.Components;

var configuration = new ConfigurationBuilder()
    .AddJsonFile(Path.Combine("data", "appsettings.json"), optional: true)
    .AddJsonFile(Path.Combine("appsettings.json"), optional: true)
    .AddUserSecrets<Program>()
    .AddEnvironmentVariables()
    .Build();

var settings = new Settings();
configuration.Bind(settings);

if (!Directory.Exists("notes"))
    Directory.CreateDirectory("notes");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton(settings)
    .AddSingleton<ChangeMonitor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
