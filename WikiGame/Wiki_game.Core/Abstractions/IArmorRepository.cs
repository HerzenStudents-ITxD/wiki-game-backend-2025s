using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Core.Abstractions
{
    public interface IArmorRepository
    {
        Task<Guid> Create(Armor armor);
        Task<Guid> Delete(Guid id);
        Task<List<Armor>> Get();
        Task<Guid> Update(Guid id, string setId, string name, string type, string stats, string description);
    }
}
