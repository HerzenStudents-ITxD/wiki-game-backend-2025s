using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Weapon
{
    private Weapon(Guid id, string name, string type, string stats, string description)
    {
        Id = id;
        Name = name;
        Type = type;
        Stats = stats;
        Description = description;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public string Type { get; } = string.Empty;
    public string Stats { get; } = string.Empty;
    public string Description { get; } = string.Empty;

    public const string TableName = "Weapons";

    //public ICollection<LocationArmor> LocationsArmors { get; set; } = new List<LocationArmor>();

    public static (Weapon Weapon, string Error) Create(Guid id, string name, string type, string stats, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Title can not be empty";
        }

        var weapon = new Weapon(id, name, type, stats, description);

        return (weapon, error);
    }
}
