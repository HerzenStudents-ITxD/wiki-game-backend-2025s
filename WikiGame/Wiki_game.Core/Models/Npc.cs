using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Npc
{
    private Npc(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description)
    {
        Id = id;
        Name = name;
        Stats = stats;
        IsEnemy = isEnemy;
        IsBoss = isBoss;
        Description = description;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public string Stats { get; } = string.Empty;
    public bool IsEnemy { get; } = false;
    public bool IsBoss { get; } = false;
    public string Description { get; } = string.Empty;

    public const string TableName = "Npcs";

    //public ICollection<LocationArmor> LocationsArmors { get; set; } = new List<LocationArmor>();

    public static (Npc Npc, string Error) Create(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Title can not be empty";
        }

        var npc = new Npc(id, name, stats, isEnemy, isBoss, description);

        return (npc, error);
    }
}
