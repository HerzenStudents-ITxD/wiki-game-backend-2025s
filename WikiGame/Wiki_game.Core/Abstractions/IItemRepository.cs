using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Core.Abstractions
{
    public interface IItemRepository
    {
        Task<Guid> Create(Item item);
        Task<Guid> Delete(Guid id);
        Task<List<Item>> Get();
        Task<Guid> Update(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable);
    }
}