using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Application.Services.Locations
{
    public interface ILocationService
    {
        Task<Guid> CreateLocation(Location location);
        Task<Guid> DeleteLocation(Guid id);
        Task<List<Location>> GetLocation();
        Task<Guid> UpdateLocation(Guid id, string name, string description);
    }
}
