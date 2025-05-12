using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Armor
{
    public Armor(string name, string type, string stats, string description)
    {
        Name = name;
        Type = type;
        Stats = stats;
        Description = description;
    }

    public Guid Id { get; set; }
    public Guid SetId { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public string Stats { get; set; }
    public string Description { get; set; }

}
