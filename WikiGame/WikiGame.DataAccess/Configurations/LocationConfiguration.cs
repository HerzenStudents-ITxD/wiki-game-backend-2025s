using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Entities;

namespace WikiGame.DataAccess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder.ToTable(Location.TableName);

            builder.HasKey(lo => lo.Id);

            builder.Property(lo => lo.Name)
                .IsRequired();

            builder.Property(lo => lo.Description)
                .IsRequired();

            //builder
            //  .HasMany(ar => ar.LocationsLocations)
            // .WithOne(aa => aa.Location)
            //.OnDelete(DeleteBehavior.NoAction)
            ;
        }
    }
}