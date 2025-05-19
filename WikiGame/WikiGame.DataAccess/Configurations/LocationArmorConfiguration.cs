//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using WikiGame.Core.Models;

//namespace WikiGame.DataAccess.Configurations
//{
//    public class LocationArmorConfiguration : IEntityTypeConfiguration<DbLocationArmor>
//    {
//        public void Configure(EntityTypeBuilder<DbLocationArmor> builder)
//        {
//            builder.ToTable(DbLocationArmor.TableName);

//            builder.HasKey(a => a.Id);

//            builder.HasAlternateKey(la => new { la.LocationId, la.ArmorId });

//            builder
//                .HasOne(la => la.Location)
//                .WithMany()
//                .HasForeignKey(la => la.LocationId)
//                .OnDelete(DeleteBehavior.Cascade);

//            builder
//                .HasOne(la => la.Armor)
//                .WithMany()
//                .HasForeignKey(la => la.ArmorId)
//                .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}