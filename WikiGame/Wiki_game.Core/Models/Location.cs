using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WikiGame.Core.Models;

public class Location
{
    public Location(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    public const string TableName = "Locations";

    //public ICollection<LocationArmor> LocationsArmors { get; set; } = new List<LocationArmor>();

    public static (Location Location, string Error) Create(Guid id, string name, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Title can not be empty";
        }

        var location = new Location(id, name, description);

        return (location, error);
    }
}
