
public class LocationService : ILocation
{   //database moet nog gemaakt worden
    private readonly MyContext _context;

    public LocationService(MyContext context)
    {
        _context = context;
    }

    public async Task<List<Location>> GetAllLocations()
    {
        return await _context.Locations.ToListAsync();
    }

    public async Task<Location> GetLocationById(int id)
    {
        return await _context.Locations.FindAsync(id);
    }

    public async Task<Location> AddLocation(CreateLocation New)
    {
        CreateLocation location = new CreateLocation
        {
            WareHouse_Id = New.WareHouse_Id,
            Code = New.Code,
            Name = New.Name,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Locations.Add(location);
        await _context.SaveChangesAsync();
        return CreateLocation; //"Location succesfully made";
    }


    public async Task<bool> UpdateLocation(Location location) // moet checken hoe ik met required fields te werk moet gaan hetzelfde geld bij POST
    {
        Location existingLocation = await _context.Locations.FindAsync(location.Id);
        
        if (existingLocation == null)
        {
            return false;
        }

        existingLocation.Code = location.Code;
        existingLocation.Name = location.Name;
        existingLocation.UpdatedAt = DateTime.UtcNow;

        _context.Locations.Update(existingLocation);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLocation(int id)
    {
        var location = await _context.Locations.FindAsync(id);
        if (location == null) return false;

        _context.Locations.Remove(location);
        return await _context.SaveChangesAsync() > 0;
    }
}
