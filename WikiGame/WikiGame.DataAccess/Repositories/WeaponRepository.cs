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
    public class WeaponRepository : IWeaponRepository
    {
        private readonly WikiDbContext _context;

        public WeaponRepository(WikiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Weapon>> Get()
        {
            var weaponEntity = await _context.Weapons
                .AsNoTracking()
                .ToListAsync();

            var weapons = weaponEntity
                .Select(w => Weapon.Create(w.Id, w.Name, w.Type, w.Stats, w.Description).Weapon)
                .ToList();

            return weapons;
        }

        public async Task<Guid> Create(Weapon weapon)
        {
            var weaponEntity = new WeaponEntity
            {
                Id = weapon.Id,
                Name = weapon.Name,
                Type = weapon.Type,
                Stats = weapon.Stats,
                Description = weapon.Description,
            };

            await _context.Weapons.AddAsync(weaponEntity);
            await _context.SaveChangesAsync();

            return weaponEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string type, string stats, string description)
        {
            await _context.Weapons
                .Where(w => w.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(w => w.Name, w => name)
                    .SetProperty(w => w.Type, w => type)
                    .SetProperty(w => w.Stats, w => stats)
                    .SetProperty(w => w.Description, w => description)
                    );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Weapons
                .Where(w => w.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}