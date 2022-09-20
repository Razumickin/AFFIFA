using AFFIFA.DataAccess;
using AFFIFA.DataAccess.Context;
using AFFIFA.Domain.Interfaces;
using AFFIFA.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddDbContext<DatabaseContext>(options => );

builder.Services.AddScoped<IEquipeService, EquipeService>();
builder.Services.AddScoped<IEquipeRepository, EquipeRepository>();

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
