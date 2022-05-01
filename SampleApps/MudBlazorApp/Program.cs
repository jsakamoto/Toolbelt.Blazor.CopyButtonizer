using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MudBlazorApp;
using Toolbelt.Blazor.CopyButtonizer;
using Toolbelt.Blazor.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();
builder.Services.AddCopyButtonizeOptions(options =>
{
    options.GetTitle = _ => "Copy to clipboard.";
    options.GetPosition = _ => CopyButtonPosition.Top;
});

await builder.Build().RunAsync();
