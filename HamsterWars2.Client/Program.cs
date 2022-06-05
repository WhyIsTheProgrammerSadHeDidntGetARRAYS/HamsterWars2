using Blazored.LocalStorage;
using HamsterWars2.Client;
using HamsterWars2.Client.Extensions;
using HamsterWars2.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.ConfigureHttpClient();
builder.Services.ConfigureHttpRequestService();
builder.Services.ConfigureAuthService();
builder.Services.ConfigureAuthenticationStateProvider();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
