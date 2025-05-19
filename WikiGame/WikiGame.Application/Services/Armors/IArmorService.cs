using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WikiGame.Core.Models;

namespace WikiGame.Application.Services.Armors
{
    public interface IArmorService
    {
        Task<Guid> CreateArmor(Armor armor);
        Task<Guid> DeleteArmor(Guid id);
        Task<List<Armor>> GetArmor();
        Task<Guid> UpdateArmor(Guid id, string setId, string name, string type, string stats, string description);
    }
}
