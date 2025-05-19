using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Application.Services.Weapons
{
    public interface IWeaponService
    {
        Task<Guid> CreateWeapon(Weapon weapon);
        Task<Guid> DeleteWeapon(Guid id);
        Task<List<Weapon>> GetWeapon();
        Task<Guid> UpdateWeapon(Guid id, string name, string type, string stats, string description);
    }
}
