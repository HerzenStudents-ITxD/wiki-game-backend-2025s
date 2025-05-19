using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.DataAccess.Entities
{
    public class WeaponEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Stats { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public const string TableName = "Weapons";

        //public ICollection<DbLocationWeapon> LocationsWeapons { get; set; } = new List<DbLocationWeapon>();
    }
}