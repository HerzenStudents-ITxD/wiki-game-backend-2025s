using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Npcs;
using WikiGame.Core.Models;
using WikiGame.DataAccess;
using WikiGame.Application.Services.Npcs;

namespace WikiGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class NpcController : ControllerBase
    {
        private readonly INpcService _npcService;

        public NpcController(INpcService npcService)
        {
            _npcService = npcService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NpcResponse>>> GetNpc()
        {
            var npcs = await _npcService.GetNpc();
            var response = npcs.Select(n => new NpcResponse(n.Id, n.Name, n.Stats, n.IsEnemy, n.IsBoss, n.Description));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateNpc([FromBody] NpcRequest request)
        {
            var (npc, error) = Npc.Create(
                Guid.NewGuid(),
                request.Name,
                request.Stats,
                request.IsEnemy,
                request.IsBoss,
                request.Description
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var npcId = await _npcService.CreateNpc(npc);

            return Ok(npcId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateNpc(Guid id, [FromBody] NpcRequest request)
        {
            var npcId = await _npcService.UpdateNpc(id, request.Name, request.Stats, request.IsEnemy, request.IsBoss, request.Description);
            return Ok(npcId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteNpc(Guid id)
        {
            return Ok(await _npcService.DeleteNpc(id));
        }
    }
}
