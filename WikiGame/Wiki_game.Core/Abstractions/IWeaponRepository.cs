using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Core.Abstractions
{
    public interface IWeaponRepository
    {
        Task<Guid> Create(Weapon weapon);
        Task<Guid> Delete(Guid id);
        Task<List<Weapon>> Get();
        Task<Guid> Update(Guid id, string name, string type, string stats, string description);
    }
}