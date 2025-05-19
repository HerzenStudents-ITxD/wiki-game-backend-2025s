using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WikiGame.API.Contracts.Locations;
using WikiGame.Core.Models;
using WikiGame.DataAccess;
using WikiGame.Application.Services.Locations;

namespace WikiGame.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<LocationResponse>>> GetLocation()
        {
            var locations = await _locationService.GetLocation();
            var response = locations.Select(l => new LocationResponse(l.Id, l.Name, l.Description));
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> CreateLocation([FromBody] LocationRequest request)
        {
            var (location, error) = Location.Create(
                Guid.NewGuid(),
                request.Name,
                request.Description
                );

            if (!string.IsNullOrEmpty(error))
            {
                return BadRequest(error);
            }

            var locationId = await _locationService.CreateLocation(location);

            return Ok(locationId);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateLocation(Guid id, [FromBody] LocationRequest request)
        {
            var locationId = await _locationService.UpdateLocation(id, request.Name, request.Description);
            return Ok(locationId);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteLocation(Guid id)
        {
            return Ok(await _locationService.DeleteLocation(id));
        }
    }
}





//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Linq.Expressions;
//using WikiGame.API.Contracts.Locations;
//using WikiGame.Core.Models;
//using WikiGame.DataAccess;

//namespace WikiGame.API.Controllers;

//[ApiController]
//[Route("[controller]")]
//public class LocationController : ControllerBase
//{
//    private readonly WikiDbContext _dbContext;

//    private Expression<Func<DbLocation, object>> GetSelectorKey(string sortItem)
//    {
//        return sortItem switch
//        {
//            "name" => location => location.Name,
//            "description" => location => location.Description,
//            _ => location => location.Id
//        };
//    }

//    public LocationController(WikiDbContext dbContext)
//    {
//        _dbContext = dbContext;
//    }

//    [HttpPost]
//    public async Task<IActionResult> Create([FromBody] CreateLocationRequest request, CancellationToken ct)
//    {
//        var location = new DbLocation(request.Name, request.Description);

//        await _dbContext.Locations.AddAsync(location, ct);
//        await _dbContext.SaveChangesAsync(ct);

//        return Ok();
//    }

//    [HttpGet]
//    public async Task<IActionResult> Get([FromQuery] GetLocationRequest request, CancellationToken ct)
//    {
//        var locationsQuery = _dbContext.Locations
//            .Where(n => !string.IsNullOrWhiteSpace(request.Search) &&
//                        n.Name.ToLower().Contains(request.Search.ToLower()));

//        Expression<Func<DbLocation, object>> selectorKey = request.SortItem?.ToLower() switch
//        {
//            "name" => location => location.Name,
//            "description" => location => location.Description,
//            _ => location => location.Id
//        };

//        locationsQuery = request.SortOrder == "desc"
//            ? locationsQuery.OrderByDescending(selectorKey)
//            : locationsQuery.OrderBy(selectorKey);

//        var locationDtos = await locationsQuery
//            .Select(n => new LocationDto(n.Id, n.Name, n.Description))
//            .ToListAsync(cancellationToken: ct);

//        return Ok(new GetLocationResponse(locationDtos));
//    }
//}