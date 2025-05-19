using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.DataAccess.Entities
{
    public class NpcEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Stats { get; set; } = string.Empty;
        public bool IsEnemy { get; set; } = false;
        public bool IsBoss { get; set; } = false;
        public string Description { get; set; } = string.Empty;

        public const string TableName = "Npcs";

        //public ICollection<DbLocationNpc> LocationsNpcs { get; set; } = new List<DbLocationNpc>();
    }
}