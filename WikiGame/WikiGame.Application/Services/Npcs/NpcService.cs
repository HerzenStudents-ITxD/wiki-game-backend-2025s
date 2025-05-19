using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Repositories;

namespace WikiGame.Application.Services.Npcs
{
    public class NpcService : INpcService
    {
        private readonly INpcRepository _npcRepository;

        public NpcService(INpcRepository npcRepository)
        {
            _npcRepository = npcRepository;
        }

        public async Task<List<Npc>> GetNpc()
        {
            return await _npcRepository.Get();
        }

        public async Task<Guid> CreateNpc(Npc npc)
        {
            return await _npcRepository.Create(npc);
        }

        public async Task<Guid> UpdateNpc(Guid id, string name, string stats, bool isEnemy, bool isBoss, string description)
        {
            return await _npcRepository.Update(id, name, stats, isEnemy, isBoss, description);
        }

        public async Task<Guid> DeleteNpc(Guid id)
        {
            return await _npcRepository.Delete(id);
        }
    }
}