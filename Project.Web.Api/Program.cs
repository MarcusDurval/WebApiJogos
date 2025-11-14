using Microsoft.EntityFrameworkCore;
using Project.Web.Api.Application.CategoriaService;
using Project.Web.Api.Application.Service;
using Project.Web.Api.Infrastructure.CategoriaRepository;
using Project.Web.Api.Infrastructure.Data;
using Project.Web.Api.Infrastructure.JogosRepository;
using Project.Web.Api.Infrastructure.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddTransient<IJogoRepository,JogoRepository>();

builder.Services.AddTransient<ICategoriaRepository, CategoriaRepository>();

builder.Services.AddAutoMapper(typeof(DTOMappingJogos));

builder.Services.AddAutoMapper(typeof(DTOMappingCategoria));

builder.Services.AddScoped<IJogoService,JogoService>();
builder.Services.AddScoped<IcategoriaService, CategoriaService>();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
