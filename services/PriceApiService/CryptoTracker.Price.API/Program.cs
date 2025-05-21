using CryptoTracker.Price.Application.Interfaces;
using CryptoTracker.Shared.Infrastructure;
using CryptoTracker.Price.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PriceDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CryptoTrackerDb")));

builder.Services.AddScoped<IPriceService, PriceService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(); 
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
