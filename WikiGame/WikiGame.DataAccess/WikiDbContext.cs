using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

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

    public DbSet<Armor> Armors => Set<Armor>();

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    optionsBuilder.UseSqlServer(_configuration.GetConnectionString("Database"));
    //}
}
