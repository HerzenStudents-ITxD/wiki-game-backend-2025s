using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Weapon
{
    public Weapon(string name, string type, string stats, string description)
    {
        WeaponName = name;
        WeaponType = type;
        WeaponStats = stats;
        WeaponDescription = description;
    }

    public Guid WeaponId { get; set; }
    public string WeaponName { get; set; }
    public string WeaponType { get; set; }
    public string WeaponStats { get; set; }
    public string WeaponDescription { get; set; }
}
