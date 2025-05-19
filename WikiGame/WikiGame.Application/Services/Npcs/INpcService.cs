using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Application.Services.Npcs
{
    public interface INpcService
    {
        Task<Guid> CreateNpc(Npc npc);
        Task<Guid> DeleteNpc(Guid id);
        Task<List<Npc>> GetNpc();
        Task<Guid> UpdateNpc(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description);
    }
}
