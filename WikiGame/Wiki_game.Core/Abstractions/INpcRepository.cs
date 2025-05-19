using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Core.Abstractions
{
    public interface INpcRepository
    {
        Task<Guid> Create(Npc npc);
        Task<Guid> Delete(Guid id);
        Task<List<Npc>> Get();
        Task<Guid> Update(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description);
    }
}