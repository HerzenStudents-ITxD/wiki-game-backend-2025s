using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Abstractions;
using WikiGame.Core.Models;
using WikiGame.DataAccess.Repositories;

namespace WikiGame.Application.Services.Weapons
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;

        public WeaponService(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public async Task<List<Weapon>> GetWeapon()
        {
            return await _weaponRepository.Get();
        }

        public async Task<Guid> CreateWeapon(Weapon weapon)
        {
            return await _weaponRepository.Create(weapon);
        }

        public async Task<Guid> UpdateWeapon(Guid id, string name, string type, string stats, string description)
        {
            return await _weaponRepository.Update(id, name, type, stats, description);
        }

        public async Task<Guid> DeleteWeapon(Guid id)
        {
            return await _weaponRepository.Delete(id);
        }
    }
}