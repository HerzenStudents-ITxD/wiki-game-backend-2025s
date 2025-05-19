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
    public class NpcConfiguration : IEntityTypeConfiguration<Npc>
    {
        public void Configure(EntityTypeBuilder<Npc> builder)
        {
            builder.ToTable(Npc.TableName);

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Name)
                .IsRequired();

            builder.Property(n => n.Stats)
                .IsRequired();

            builder.Property(n => n.IsEnemy)
                .IsRequired();

            builder.Property(n => n.IsBoss)
                .IsRequired();

            builder.Property(n => n.Description)
                .IsRequired();

            //builder
            //  .HasMany(ar => ar.LocationsNpcs)
            // .WithOne(aa => aa.Npc)
            //.OnDelete(DeleteBehavior.NoAction)
            ;
        }
    }
}