using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class ArmorSet
{
    public ArmorSet(string setName)
    {
        SetName = setName;
    }

    public Guid SetId { get; set; }
    public string SetName { get; set; }
}
