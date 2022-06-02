using HamsterWars2.Client.Authentication;
using HamsterWars2.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HamsterWars2.Client.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureHttpClient(this IServiceCollection services)
        {
            services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5001") });
        }
        public static void ConfigureHttpRequestService(this IServiceCollection services)
        {
            services.AddScoped<IHttpRequestService, HttpRequestService>();
        }
        public static void ConfigureAuthService(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();

            services.AddScoped<AuthenticationStateProvider, AuthStateProvider>();
        }
    }
}
