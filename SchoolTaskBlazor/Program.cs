using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SchoolTaskBlazor;
using SchoolTaskBlazor.Services;
using SchoolTaskBlazor.Services.Contracts;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7014/") });
builder.Services.AddScoped<ISchoolService, SchoolService>();


await builder.Build().RunAsync();
