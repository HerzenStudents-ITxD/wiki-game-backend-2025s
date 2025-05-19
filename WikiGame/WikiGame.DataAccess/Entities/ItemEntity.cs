using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.DataAccess.Entities
{
    public class ItemEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Kind { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDroppable { get; set; } = false;
        public bool IsSellable { get; set; } = false;

        public const string TableName = "Items";

        //public ICollection<DbLocationItem> LocationsItems { get; set; } = new List<DbLocationItem>();
    }
}