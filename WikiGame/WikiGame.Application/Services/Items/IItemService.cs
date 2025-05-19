using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Application.Services.Items
{
    public interface IItemService
    {
        Task<Guid> CreateItem(Item item);
        Task<Guid> DeleteItem(Guid id);
        Task<List<Item>> GetItem();
        Task<Guid> UpdateItem(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable);
    }
}