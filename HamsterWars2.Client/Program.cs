using Blazored.LocalStorage;
using HamsterWars2.Client;
using HamsterWars2.Client.Extensions;
using HamsterWars2.Client.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
builder.Services.ConfigureHttpClient();
builder.Services.ConfigureHttpRequestService();
//builder.Services.AddScoped<IHttpRequestService, HttpRequestService>();
builder.Services.ConfigureAuthService();
//builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
