using Microsoft.EntityFrameworkCore;
using WikiGame.DataAccess;
using WikiGame.DataAccess.Repositories;
using WikiGame.Core.Abstractions;
using WikiGame.Application.Services.Armors;
using WikiGame.Application.Services.Locations;
using WikiGame.Application.Services.Weapons;
using WikiGame.Application.Services.Npcs;
using WikiGame.Application.Services.Items;

var builder = WebApplication.CreateBuilder(args);

//builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddScoped<WikiDbContext>();

builder.Services.AddDbContext<WikiDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped<IArmorService, ArmorService>();
builder.Services.AddScoped<IArmorRepository, ArmorRepository>();

builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ILocationRepository, LocationRepository>();

builder.Services.AddScoped<IWeaponService, WeaponService>();
builder.Services.AddScoped<IWeaponRepository, WeaponRepository>();

builder.Services.AddScoped<INpcService, NpcService>();
builder.Services.AddScoped<INpcRepository, NpcRepository>();

builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin();
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
    });
});

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<WikiDbContext>();
//    await dbContext.Database.EnsureCreatedAsync();
//}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
