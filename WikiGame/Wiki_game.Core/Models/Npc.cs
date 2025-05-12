using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class Npc
{
    public Npc(string name, string stats, bool is_enemy, bool is_boss, string description)
    {
        NpcName = name;
        NpcStats = stats;
        NpcIsEnemy = is_enemy;
        NpcIsBoss = is_boss;
        NpcDescription = description;
    }

    public Guid NpcId { get; set; }
    public string NpcName { get; set; }
    public string NpcStats { get; set; }
    public bool NpcIsEnemy { get; set; }
    public bool NpcIsBoss { get; set; }
    public string NpcDescription { get; set; }
}
