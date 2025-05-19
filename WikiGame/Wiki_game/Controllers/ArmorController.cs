using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Armors;
using WikiGame.Core.Models;
using WikiGame.DataAccess;
using WikiGame.Application.Services.Armors;

namespace WikiGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ArmorController : ControllerBase
    {
        private readonly IArmorService _armorService;

        public ArmorController(IArmorService armorService)
        {
            _armorService = armorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ArmorResponse>>> GetArmor()
        {
            var armors = await _armorService.GetArmor();
            var response = armors.Select(a => new ArmorResponse(a.Id, a.SetId, a.Name, a.Type, a.Stats, a.Description));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateArmor([FromBody] ArmorRequest request)
        {
            var (armor, error) = Armor.Create(
                Guid.NewGuid(),
                request.SetId,
                request.Name,
                request.Type,
                request.Stats,
                request.Description
                );
            
            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var armorId = await _armorService.CreateArmor(armor);

            return Ok(armorId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateArmor(Guid id, [FromBody] ArmorRequest request)
        {
            var armorId = await _armorService.UpdateArmor(id, request.SetId, request.Name, request.Type, request.Stats, request.Description);
            return Ok(armorId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteArmor(Guid id)
        {
            return Ok(await _armorService.DeleteArmor(id));
        }
    }
}

//[ApiController]
//[Route("[controller]")]
//public class ArmorController : ControllerBase
//{
//    private readonly WikiDbContext _dbContext;

//    private Expression<Func<DbArmor, object>> GetSelectorKey(string sortItem)
//    {
//        return sortItem switch
//        {
//            "setId" => armor => armor.SetId,
//            "name" => armor => armor.Name,
//            "type" => armor => armor.Type,
//            "stats" => armor => armor.Stats,
//            "description" => armor => armor.Description,
//            _ => armor => armor.Id
//        };
//    }

//    public ArmorController(WikiDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromBody] CreateArmorRequest request, CancellationToken ct)
//    {
//        var armor = new DbArmor(request.SetId, request.Name, request.Type, request.Stats, request.Description);

//        await _dbContext.Armors.AddAsync(armor, ct);
//        await _dbContext.SaveChangesAsync(ct);

//        return Ok();
//    }

//    [HttpGet]
//    public async Task<IActionResult> Get([FromQuery] GetArmorRequest request, CancellationToken ct)
//    {
//        var armorsQuery = _dbContext.Armors
//            .Where(n => !string.IsNullOrWhiteSpace(request.Search) &&
//                        n.Name.ToLower().Contains(request.Search.ToLower()));

//        Expression<Func<DbArmor, object>> selectorKey = request.SortItem?.ToLower() switch
//        {
//            "setId" => armor => armor.SetId,
//            "name" => armor => armor.Name,
//            "type" => armor => armor.Type,
//            "stats" => armor => armor.Stats,
//            "description" => armor => armor.Description,
//            _ => armor => armor.Id
//        };

//        armorsQuery = request.SortOrder == "desc"
//            ? armorsQuery.OrderByDescending(selectorKey)
//            : armorsQuery.OrderBy(selectorKey);

//        var armorDtos = await armorsQuery
//            .Select(n => new ArmorDto(n.Id, n.SetId, n.Name, n.Type, n.Stats, n.Description))
//            .ToListAsync(cancellationToken: ct);

//        return Ok(new GetArmorResponse(armorDtos));
//    }
//}

