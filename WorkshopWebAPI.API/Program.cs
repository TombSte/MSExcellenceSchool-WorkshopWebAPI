using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WorkshopWebAPI.API.Commands;
using WorkshopWebAPI.API.DTO;
using WorkshopWebAPI.API.Persistence;
using WorkshopWebAPI.API.Profiles;
using WorkshopWebAPI.API.Services.Implementations;
using WorkshopWebAPI.API.Services.Interfaces;
using WorkshopWebAPI.API.Validators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AudiDbContext>(options => options.UseSqlServer(builder.Configuration["ConnectionStrings:DefaultConnection"]));

//mediatr registrations
builder.Services.AddMediatR(typeof(GetUserCommandHandler));

builder.Services.AddScoped<ICarService, CarService>();

//Automapper
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new ApplicationMappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

//Validators
builder.Services.AddTransient<IValidator<CustomerInputDTO>, CustomerValidator>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
