using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
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

            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Access-Control-Allow-Origin", "*");

            builder.Services.AddScoped(sp => httpClient);


            builder.Services.AddCors(o =>
            {
                o.AddDefaultPolicy(policy =>
                                   {
                                       policy.WithOrigins("https://gsnha.duckdns.org:8123").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().Build();
                                   });
                
            });


            var app = builder.Build();
            await app.RunAsync();
        }
    }
}
