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
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable(Item.TableName);

            builder.HasKey(it => it.Id);

            builder.Property(it => it.Name)
                .IsRequired();

            builder.Property(it => it.Kind)
                .IsRequired();

            builder.Property(it => it.Description)
                .IsRequired();

            builder.Property(it => it.IsDroppable)
                .IsRequired();

            builder.Property(it => it.IsSellable)
                .IsRequired();

            //builder
            //  .HasMany(ar => ar.LocationsItems)
            // .WithOne(aa => aa.Item)
            //.OnDelete(DeleteBehavior.NoAction)
            ;
        }
    }
}