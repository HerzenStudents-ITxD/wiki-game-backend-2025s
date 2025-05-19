using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Core.Abstractions
{
    public interface ILocationRepository
    {
        Task<Guid> Create(Location location);
        Task<Guid> Delete(Guid id);
        Task<List<Location>> Get();
        Task<Guid> Update(Guid id, string name, string description);
    }
}