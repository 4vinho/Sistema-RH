using System.Text;
using IdentityServiceAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

//ServiceRegister
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();


//DB
builder.Services.AddDbContext<IdentityServiceAPIAppDbContext>(options => options
    .UseSqlServer("Server = WIN-T0TUUU3CIMK\\SQLEXPRESS;Database=IdentityServiceAPI;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"));


//Identity
builder.Services
    .AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityServiceAPIAppDbContext>();

builder.Services.AddAuthorization();

//Controllers
builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//--------------------------------------------//
var app = builder.Build();


//Identity
await CreateProfileUsersAsync(app);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();
app.Run();

async Task CreateProfileUsersAsync(WebApplication app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<ISeedUserRoleInitial>();
        await service.SeedRolesAsync();
        await service.SeedUsersAsync();
    }
}