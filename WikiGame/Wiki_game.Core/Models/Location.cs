using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Location
{
    public Location(string name, string description)
    {
        LocationName = name;
        LocationDescription = description;
    }

    public Guid LocationId { get; set; }
    public string LocationName { get; set; }
    public string LocationDescription { get; set; }
}
