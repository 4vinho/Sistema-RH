using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using RHFrontEnd;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//MudBlazor
builder.Services.AddMudServices();

//HttpClient
builder.Services.AddHttpClient<IEmployeeService, EmployeeService>(c =>
    c.BaseAddress = new Uri(Config.EmployeeServiceAPI)
);
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

var host = builder.Build();

await builder.Build().RunAsync();
