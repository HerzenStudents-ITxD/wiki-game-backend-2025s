using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.DataAccess.Entities
{
    public class ArmorEntity
    {
        public Guid Id { get; set; }
        public string SetId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Stats { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public const string TableName = "Armors";

        //public ICollection<DbLocationArmor> LocationsArmors { get; set; } = new List<DbLocationArmor>();
    }
}
