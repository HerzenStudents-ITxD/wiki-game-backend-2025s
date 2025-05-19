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
    public class ArmorRepository : IArmorRepository
    {
        private readonly WikiDbContext _context;

        public ArmorRepository(WikiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Armor>> Get()
        {
            var armorEntity = await _context.Armors
                .AsNoTracking()
                .ToListAsync();

            var armors = armorEntity
                .Select(a => Armor.Create(a.Id, a.SetId, a.Name, a.Type, a.Stats, a.Description).Armor)
                .ToList();

            return armors;
        }

        public async Task<Guid> Create(Armor armor)
        {
            var armorEntity = new ArmorEntity
            {
                Id = armor.Id,
                SetId = armor.SetId,
                Name = armor.Name,
                Type = armor.Type,
                Stats = armor.Stats,
                Description = armor.Description,
            };

            await _context.Armors.AddAsync(armorEntity);
            await _context.SaveChangesAsync();

            return armorEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string setId, string name, string type, string stats, string description)
        {
            await _context.Armors
                .Where(a => a.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.SetId, a => setId)
                    .SetProperty(a => a.Name, a => name)
                    .SetProperty(a => a.Type, a => type)
                    .SetProperty(a => a.Stats, a => stats)
                    .SetProperty(a => a.Description, a => description)
                    );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Armors
                .Where (a => a.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}
