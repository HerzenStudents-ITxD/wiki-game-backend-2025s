using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Repositories;

namespace WikiGame.Application.Services.Items
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<List<Item>> GetItem()
        {
            return await _itemRepository.Get();
        }

        public async Task<Guid> CreateItem(Item item)
        {
            return await _itemRepository.Create(item);
        }

        public async Task<Guid> UpdateItem(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable)
        {
            return await _itemRepository.Update(id, name, kind, description, isDroppable, isSellable);
        }

        public async Task<Guid> DeleteItem(Guid id)
        {
            return await _itemRepository.Delete(id);
        }
    }
}