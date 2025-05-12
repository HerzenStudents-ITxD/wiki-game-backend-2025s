using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Item
{
    public Item(string name, string kind, string description, bool is_droppable, bool is_sellable)
    {
        ItemName = name;
        ItemKind = kind;
        ItemDescription = description;
        ItemIsDroppable = is_droppable;
        ItemIsSellable = is_sellable;
    }

    public Guid ItemId { get; set; }
    public string ItemName { get; set; }
    public string ItemKind { get; set; }
    public string ItemDescription { get; set; }
    public bool ItemIsDroppable { get; set; }
    public bool ItemIsSellable { get; set; }
}
