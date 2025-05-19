using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Weapons;
using WikiGame.Core.Models;
using WikiGame.DataAccess;
using WikiGame.Application.Services.Weapons;

namespace WikiGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpGet]
        public async Task<ActionResult<List<WeaponResponse>>> GetWeapon()
        {
            var weapons = await _weaponService.GetWeapon();
            var response = weapons.Select(w => new WeaponResponse(w.Id, w.Name, w.Type, w.Stats, w.Description));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateWeapon([FromBody] WeaponRequest request)
        {
            var (weapon, error) = Weapon.Create(
                Guid.NewGuid(),
                request.Name,
                request.Type,
                request.Stats,
                request.Description
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var weaponId = await _weaponService.CreateWeapon(weapon);

            return Ok(weaponId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateWeapon(Guid id, [FromBody] WeaponRequest request)
        {
            var weaponId = await _weaponService.UpdateWeapon(id, request.Name, request.Type, request.Stats, request.Description);
            return Ok(weaponId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteWeapon(Guid id)
        {
            return Ok(await _weaponService.DeleteWeapon(id));
        }
    }
}