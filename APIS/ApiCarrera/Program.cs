using ApiCarrera;
using ApiCarrera.DbContexts;
using ApiCarrera.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Registra la conexion a la BD SQL
var connectionString = builder.Configuration.GetConnectionString("DbEstudiante");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//Registrar el automapper
IMapper mapper = MapingConfig.RegisterMaps().CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//Inyeccion de dependencia para IProductRepository
builder.Services.AddScoped<ICarreraRepository, CarreraSQLRepository>();


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

app.UseHttpsRedirection();

app.UseCors("MyAllowedOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();
