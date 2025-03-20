using AutoMapper;
using EmployeeServiceAPI;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//
builder.Services.AddTransient<IEmployeeRepository, EmployeeRepository>();

//CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(
        "DevelopmentPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        }
    );
});

//Database
builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));

//Controllers
builder.Services.AddControllers();

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Mapper
var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Employee, EmployeeDTO>().ReverseMap();
});

var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

//CORS
app.UseCors("DevelopmentPolicy");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();
