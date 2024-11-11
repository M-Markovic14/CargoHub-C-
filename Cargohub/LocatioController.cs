using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocation _locationService;

    public LocationController(ILocation locationService)
    {
        _locationService = locationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll() // moet nog gefixed worden
    {
        Location locations = await _locationService.GetAllLocations();
        return Ok(locations);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        Location location = await _locationService.GetLocationById(id);
        if (location == null)
        {
            return NotFound();
        }
        return Ok(location);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLocation New)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        CreateLocation createdLocation = await _locationService.AddLocation(New);
        return CreatedAtAction(nameof(Get), new { id = createdLocation.Id }, createdLocation);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Location location)
    {
        if (id != location.Id)
        {
            return BadRequest($"Location Id {id} does not exist");
        }
        bool updated = await _locationService.UpdateLocation(location);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _locationService.DeleteLocation(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}
