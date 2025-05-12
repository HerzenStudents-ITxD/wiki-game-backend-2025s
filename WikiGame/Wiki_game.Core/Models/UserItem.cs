using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WikiGame.Core.Models;

public class UserItem
{
    public Guid UserId { get; set; }
    public Guid ItemId { get; set; }
}
