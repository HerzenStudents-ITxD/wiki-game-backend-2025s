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
    public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
    {
        public void Configure(EntityTypeBuilder<Weapon> builder)
        {
            builder.ToTable(Weapon.TableName);

            builder.HasKey(we => we.Id);

            builder.Property(we => we.Name)
                .IsRequired();

            builder.Property(we => we.Type)
                .IsRequired();

            builder.Property(we => we.Stats)
                .IsRequired();

            builder.Property(we => we.Description)
                .IsRequired();

            //builder
            //  .HasMany(ar => ar.LocationsWeapons)
            // .WithOne(aa => aa.Weapon)
            //.OnDelete(DeleteBehavior.NoAction)
            ;
        }
    }
}