using ApiEstudiante.DbContexts;
using ApiEstudiante.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

var cnn = builder.Configuration.GetConnectionString("DbEstudiante");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(cnn));

IMapper mapper = ApiEstudiante.MappingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


// Config la DI para la IEstudianteRepository

builder.Services.AddScoped<IEstudianteRepository, EstudianteSQLRepository>();

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("MyAllowedOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
