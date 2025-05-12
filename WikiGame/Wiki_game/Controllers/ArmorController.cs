using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Armors;
using WikiGame.Core.Models;
using WikiGame.DataAccess;

namespace WikiGame.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ArmorController : ControllerBase
{
    private readonly WikiDbContext _dbContext;

    private Expression<Func<Armor, object>> GetSelectorKey(string sortItem)
    {
        return sortItem switch
        {
            "name" => armor => armor.Name,
            "type" => armor => armor.Type,
            "stats" => armor => armor.Stats,
            "description" => armor => armor.Description,
            _ => armor => armor.Id
        };
    }

    public ArmorController(WikiDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateArmorRequest request, CancellationToken ct)
    {
        var armor = new Armor(request.Name, request.Type, request.Stats, request.Description);

        await _dbContext.Armors.AddAsync(armor, ct);
        await _dbContext.SaveChangesAsync(ct);

        return Ok();
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] GetArmorRequest request, CancellationToken ct)
    {
        var armorsQuery = _dbContext.Armors
            .Where(n => !string.IsNullOrWhiteSpace(request.Search) &&
                        n.Name.ToLower().Contains(request.Search.ToLower()));

        Expression<Func<Armor, object>> selectorKey = request.SortItem?.ToLower() switch
        {
            "name" => armor => armor.Name,
            "type" => armor => armor.Type,
            "stats" => armor => armor.Stats,
            "description" => armor => armor.Description,
            _ => armor => armor.Id
        };

        armorsQuery = request.SortOrder == "desc"
            ? armorsQuery.OrderByDescending(selectorKey)
            : armorsQuery.OrderBy(selectorKey);

        var armorDtos = await armorsQuery
            .Select(n => new ArmorDto(n.Id, n.SetId, n.Name, n.Type, n.Stats, n.Description))
            .ToListAsync(cancellationToken: ct);

        return Ok(new GetArmorResponse(armorDtos));
    }
}

