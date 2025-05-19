using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Item
{
    private Item(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable)
    {
        Id = id;
        Name = name;
        Kind = kind;
        Description = description;
        IsDroppable = isDroppable;
        IsSellable = isSellable;
    }

    public Guid Id { get; }
    public string Name { get; } = string.Empty;
    public string Kind { get; } = string.Empty;
    public string Description { get; } = string.Empty;
    public bool IsDroppable { get; } = false;
    public bool IsSellable { get; } = false;

    public const string TableName = "Items";

    //public ICollection<LocationArmor> LocationsArmors { get; set; } = new List<LocationArmor>();

    public static (Item Item, string Error) Create(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable)
    {
        var error = string.Empty;

        if (string.IsNullOrEmpty(name))
        {
            error = "Title can not be empty";
        }

        var item = new Item(id, name, kind, description, isDroppable, isSellable);

        return (item, error);
    }
}
