using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HomeControl
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddCors(o =>
            {
                o.AddDefaultPolicy(policy =>
                                   {
                                       policy.WithOrigins("https://gsnha.duckdns.org:8123").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                                   });
            });


            var app = builder.Build();


            await app.RunAsync();
        }
    }
}
