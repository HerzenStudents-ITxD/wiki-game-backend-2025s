using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Repositories;

namespace WikiGame.Application.Services.Locations
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;

        public LocationService(ILocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public async Task<List<Location>> GetLocation()
        {
            return await _locationRepository.Get();
        }

        public async Task<Guid> CreateLocation(Location location)
        {
            return await _locationRepository.Create(location);
        }

        public async Task<Guid> UpdateLocation(Guid id, string name, string description)
        {
            return await _locationRepository.Update(id, name, description);
        }

        public async Task<Guid> DeleteLocation(Guid id)
        {
            return await _locationRepository.Delete(id);
        }
    }
}