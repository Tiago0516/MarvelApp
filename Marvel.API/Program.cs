using Microsoft.EntityFrameworkCore;
using Marvel.Infrastructure.Data;
using Microsoft.OpenApi.Models;
using Marvel.Application.Services;
using Marvel.Domain.Interfaces;
using Marvel.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

var publicKey = "10e5534cc83c8e8cf89aa88a1b361494";
var privateKey = "f9ad083552bc4e103c4be47443a9232fefbec0cd";
  

// Configurar DbContext con SQL Server
builder.Services.AddDbContext<MarvelDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IComicRepository, ComicRepository>();
builder.Services.AddScoped<IFavoritoRepository, FavoritoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

// builder.Services.AddScoped<ComicService>();
builder.Services.AddHttpClient<ComicService>();
builder.Services.AddScoped<ComicService>(provider =>
{
    var httpClient = provider.GetRequiredService<HttpClient>();
    var comicRepository = provider.GetRequiredService<IComicRepository>();
    return new ComicService(httpClient, comicRepository, publicKey, privateKey);
});
builder.Services.AddScoped<FavoritoService>();
builder.Services.AddScoped<UsuarioService>();

builder.Services.AddControllers();
// Agregar servicios de Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Marvel API", Version = "v1" });
});



var app = builder.Build();

// Configurar Swagger en desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
