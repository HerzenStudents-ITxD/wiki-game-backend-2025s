using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WikiGame.Core.Models;

public class Armor
{
    //public const int MAX_NAME_LENGTH = 50;
    private Armor(Guid id, string setId, string name, string type, string stats, string description)
    {
        Id = id;
        SetId = setId;
        Name = name;
        Type = type;
        Stats = stats;
        Description = description;
    }

    public Guid Id { get; }
    public string SetId { get; }
    public string Name { get; } = string.Empty;
    public string Type { get; } = string.Empty;
    public string Stats { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    public const string TableName = "Armors";

    //public ICollection<LocationArmor> LocationsArmors { get; set; } = new List<LocationArmor>();

    public static (Armor Armor, string Error) Create(Guid id, string setId, string name, string type, string stats, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Title can not be empty";
        }

        var armor = new Armor(id, setId, name, type, stats, description);

        return (armor, error);
    }
}

