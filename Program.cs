using HADotNet.Core;
using HADotNet.Core.Clients;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Radzen;
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

            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

            builder.Services.AddScoped(sp => httpClient);

            //Radzen
            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();
            builder.Services.AddScoped<TooltipService>();
            builder.Services.AddScoped<ContextMenuService>();

            //HADotNet
            builder.Services.AddSingleton(sp => ClientFactory.GetClient<StatesClient>());
            builder.Services.AddSingleton(sp => ClientFactory.GetClient<ServiceClient>());

            ClientFactory.Initialize("https://gsnha.duckdns.org:8123", "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiI5NzZmZWRmNjA5ZGM0YTk5YjY3MDkzZDY2OGQzMTk1MSIsImlhdCI6MTY2OTU2MDYxOCwiZXhwIjoxOTg0OTIwNjE4fQ.d7gA8Xglhv6SCCAfkylB9eM_qykuT_bNpze8wWVZhGY");

            var app = builder.Build();
            await app.RunAsync();
        }
    }
}
