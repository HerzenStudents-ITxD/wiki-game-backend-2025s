using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Entities;

namespace WikiGame.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly WikiDbContext _context;

        public ItemRepository(WikiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Item>> Get()
        {
            var itemEntity = await _context.Items
                .AsNoTracking()
                .ToListAsync();

            var items = itemEntity
                .Select(i => Item.Create(i.Id, i.Name, i.Kind, i.Description, i.IsDroppable, i.IsSellable).Item)
                .ToList();

            return items;
        }

        public async Task<Guid> Create(Item item)
        {
            var itemEntity = new ItemEntity
            {
                Id = item.Id,
                Name = item.Name,
                Kind = item.Kind,
                Description = item.Description,
                IsDroppable = item.IsDroppable,
                IsSellable = item.IsSellable,
            };

            await _context.Items.AddAsync(itemEntity);
            await _context.SaveChangesAsync();

            return itemEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string kind, string description, bool isDroppable, bool isSellable)
        {
            await _context.Items
                .Where(i => i.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(i => i.Name, i => name)
                    .SetProperty(i => i.Kind, i => kind)
                    .SetProperty(i => i.Description, i => description)
                    .SetProperty(i => i.IsDroppable, i => isDroppable)
                    .SetProperty(i => i.IsSellable, i => isSellable)
                    );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Items
                .Where(i => i.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}