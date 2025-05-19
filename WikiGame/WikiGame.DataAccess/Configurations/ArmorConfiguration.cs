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
    public class ArmorConfiguration : IEntityTypeConfiguration<Armor>
    {
        public void Configure(EntityTypeBuilder<Armor> builder)
        {
            builder.ToTable(Armor.TableName);

            builder.HasKey(ar => ar.Id);

            builder.Property(ar => ar.SetId)
                .IsRequired();

            builder.Property(ar => ar.Name)
                .IsRequired();

            builder.Property(ar => ar.Type)
                .IsRequired();

            builder.Property(ar => ar.Stats)
                .IsRequired();

            builder.Property(ar => ar.Description)
                .IsRequired();

            //builder
              //  .HasMany(ar => ar.LocationsArmors)
               // .WithOne(aa => aa.Armor)
                //.OnDelete(DeleteBehavior.NoAction)
                ;
        }
    }
}
