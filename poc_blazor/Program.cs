using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using poc_blazor;
using MudBlazor.Services;
using Blazored.LocalStorage;
using poc_blazor.Infrastructure;
using poc_blazor.Shared.Services;
using poc_blazor.Shared.IServices;
using poc_blazor.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.Authorization;

public class Program
{
    public static async Task Main(string [] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");

        builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
        builder.Services.AddBlazoredLocalStorage();
        builder.Services.AddMudServices();

        builder.Services.AddHttpClient("Auth", client => client.BaseAddress = new Uri("https://apipoc20221227200802.azurewebsites.net/"));
            //.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
        builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("Auth"));

        builder.Services.AddHttpClient<PublicClient>(client => client.BaseAddress = new Uri("https://apipoc20221227200802.azurewebsites.net/"));

        builder.Services.AddScoped<IProductService, ProductService>();
        builder.Services.AddScoped<IUserService, UserService>();

        var host = builder.Build();
        await host.SetDefaultCulture();
        await host.RunAsync();
    }
}
