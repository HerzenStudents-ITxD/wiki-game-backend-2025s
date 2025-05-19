using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Items;
using WikiGame.Core.Models;
using WikiGame.DataAccess;
using WikiGame.Application.Services.Items;

namespace WikiGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ItemResponse>>> GetItem()
        {
            var items = await _itemService.GetItem();
            var response = items.Select(i => new ItemResponse(i.Id, i.Name, i.Kind, i.Description, i.IsDroppable, i.IsSellable));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateItem([FromBody] ItemRequest request)
        {
            var (item, error) = Item.Create(
                Guid.NewGuid(),
                request.Name,
                request.Kind,
                request.Description,
                request.IsDroppable,
                request.IsSellable
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var itemId = await _itemService.CreateItem(item);

            return Ok(itemId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateItem(Guid id, [FromBody] ItemRequest request)
        {
            var itemId = await _itemService.UpdateItem(id, request.Name, request.Kind, request.Description, request.IsDroppable, request.IsSellable);
            return Ok(itemId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteItem(Guid id)
        {
            return Ok(await _itemService.DeleteItem(id));
        }
    }
}