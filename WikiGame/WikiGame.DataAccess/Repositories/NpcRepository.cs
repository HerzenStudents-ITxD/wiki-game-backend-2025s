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
    public class NpcRepository : INpcRepository
    {
        private readonly WikiDbContext _context;

        public NpcRepository(WikiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Npc>> Get()
        {
            var npcEntity = await _context.Npcs
                .AsNoTracking()
                .ToListAsync();

            var npcs = npcEntity
                .Select(n => Npc.Create(n.Id, n.Name, n.Stats, n.IsEnemy, n.IsBoss, n.Description).Npc)
                .ToList();

            return npcs;
        }

        public async Task<Guid> Create(Npc npc)
        {
            var npcEntity = new NpcEntity
            {
                Id = npc.Id,
                Name = npc.Name,
                Stats = npc.Stats,
                IsEnemy = npc.IsEnemy,
                IsBoss = npc.IsBoss,
                Description = npc.Description,
            };

            await _context.Npcs.AddAsync(npcEntity);
            await _context.SaveChangesAsync();

            return npcEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description)
        {
            await _context.Npcs
                .Where(n => n.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(n => n.Name, n => name)
                    .SetProperty(n => n.Stats, n => stats)
                    .SetProperty(n => n.IsEnemy, n => isEnemy)
                    .SetProperty(n => n.IsBoss, n => isBoss)
                    .SetProperty(n => n.Description, n => description)
                    );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Npcs
                .Where(n => n.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}