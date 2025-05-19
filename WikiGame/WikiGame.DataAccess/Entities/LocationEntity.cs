using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.DataAccess.Entities
{
    public class LocationEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public const string TableName = "Locations";

        //public ICollection<DbLocationLocation> LocationsLocations { get; set; } = new List<DbLocationLocation>();
    }
}