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
    public class LocationRepository : ILocationRepository
    {
        private readonly WikiDbContext _context;

        public LocationRepository(WikiDbContext context)
        {
            _context = context;
        }

        public async Task<List<Location>> Get()
        {
            var locationEntity = await _context.Locations
                .AsNoTracking()
                .ToListAsync();

            var locations = locationEntity
                .Select(l => Location.Create(l.Id, l.Name, l.Description).Location)
                .ToList();

            return locations;
        }

        public async Task<Guid> Create(Location location)
        {
            var locationEntity = new LocationEntity
            {
                Id = location.Id,
                Name = location.Name,
                Description = location.Description,
            };

            await _context.Locations.AddAsync(locationEntity);
            await _context.SaveChangesAsync();

            return locationEntity.Id;
        }

        public async Task<Guid> Update(Guid id, string name, string description)
        {
            await _context.Locations
                .Where(l => l.Id == id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(l => l.Name, l => name)
                    .SetProperty(l => l.Description, l => description)
                    );

            return id;
        }

        public async Task<Guid> Delete(Guid id)
        {
            await _context.Locations
                .Where(l => l.Id == id)
                .ExecuteDeleteAsync();

            return id;
        }
    }
}