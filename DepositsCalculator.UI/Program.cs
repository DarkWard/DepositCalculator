using DepositsCalculator.UI.Constants;
using DepositsCalculator.UI.Services;
using DepositsCalculator.UI.Services.Interfaces;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DepositsCalculator.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient<IDepositsApiRequestService, DepositsApiRequestService>(client =>
                client.BaseAddress = new Uri(
                    builder.Configuration[AppSettingsConstants.ApiAddress]));

            await builder.Build().RunAsync();
        }
    }
}