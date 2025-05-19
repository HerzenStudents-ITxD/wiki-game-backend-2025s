using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Entities;

namespace WikiGame.DataAccess;

public class WikiDbContext : DbContext
{
    //private readonly IConfiguration _configuration;

    //public WikiDbContext(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //}

    public WikiDbContext(DbContextOptions<WikiDbContext> options)
        : base(options)
    {
    }

    public DbSet<ArmorEntity> Armors {  get; set; }
    public DbSet<LocationEntity> Locations {  get; set; }
    public DbSet<WeaponEntity> Weapons {  get; set; }
    public DbSet<NpcEntity> Npcs { get; set; }
    public DbSet<ItemEntity> Items { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
    //}
}
