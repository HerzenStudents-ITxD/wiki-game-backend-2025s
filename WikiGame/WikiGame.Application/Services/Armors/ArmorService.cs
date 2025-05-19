using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Repositories;

namespace WikiGame.Application.Services.Armors
{
    public class ArmorService : IArmorService
    {
        private readonly IArmorRepository _armorRepository;

        public ArmorService(IArmorRepository armorRepository)
        {
            _armorRepository = armorRepository;
        }

        public async Task<List<Armor>> GetArmor()
        {
            return await _armorRepository.Get();
        }

        public async Task<Guid> CreateArmor(Armor armor)
        {
            return await _armorRepository.Create(armor);
        }

        public async Task<Guid> UpdateArmor(Guid id, string setId, string name, string type, string stats, string description)
        {
            return await _armorRepository.Update(id, setId, name, type, stats, description);
        }

        public async Task<Guid> DeleteArmor(Guid id)
        {
            return await _armorRepository.Delete(id);
        }
    }
}
