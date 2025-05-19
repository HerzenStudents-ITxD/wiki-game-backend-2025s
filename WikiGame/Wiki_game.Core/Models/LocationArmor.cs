using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WikiGame.Core.Models;

public class LocationArmor
{
    public const string TableName = "LocationsArmors";

    public Guid Id { get; set; }
    //public Guid LocationId { get; set; }
    //public DbLocation Location { get; set; }
    //public Guid ArmorId { get; set; }
    //public Armor Armor { get; set; }
}