using AFFIFA.DataAccess;
using AFFIFA.Domain.Interfaces;
using AFFIFA.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Services
builder.Services.AddScoped<IEquipeService, EquipeService>();
builder.Services.AddScoped<IJogadorService, JogadorService>();
builder.Services.AddScoped<ICampeonatoService, CampeonatoService>();
builder.Services.AddScoped<IPartidaService, PartidaService>();

//Repositories
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();
builder.Services.AddScoped<IJogadorRepository, JogadorRepository>();
builder.Services.AddScoped<ICampeonatoRepository, CampeonatoRepository>();
builder.Services.AddScoped<IPartidaRepository, PartidaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:3000");
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
