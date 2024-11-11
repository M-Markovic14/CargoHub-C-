
using System.ComponentModel.DataAnnotations;

public class Location
{
    public int Id { get; set; }
    public int WareHouse_Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }   
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

public class CreateLocation
{
    [Required]
    public Guid id { get; set; } // moet nog kijken hoe GUID precies werkt

    [Required]
    public string Code { get; set; }

    [Required]
    public string Name { get; set; }
    // WareHouse_Id could be passed by the user or inferred from their session/user data.
    [Required]
    public int WareHouse_Id { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}

