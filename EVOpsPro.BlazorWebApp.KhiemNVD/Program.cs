using EVOpsPro.BlazorWebApp.KhiemNVD;
using EVOpsPro.BlazorWebApp.KhiemNVD.GraphQLClient;
using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IGraphQLClient>(c => new GraphQLHttpClient(builder.Configuration["GraphQLURI"], new NewtonsoftJsonSerializer()));
builder.Services.AddScoped<GraphQLConsumer>();
builder.Services.AddScoped<AuthService>();

await builder.Build().RunAsync();
