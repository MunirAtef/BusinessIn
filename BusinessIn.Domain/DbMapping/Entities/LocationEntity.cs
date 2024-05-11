using System.ComponentModel.DataAnnotations;

namespace BusinessIn.Domain.DbMapping.Entities;

public class LocationEntity {
    public Guid Id { set; get; }
    
    [MaxLength(20, ErrorMessage = "Postal code cannot exceed 200 chars")]
    public string PostalCode { set; get; } = null!;
    
    [MaxLength(50, ErrorMessage = "Region name cannot exceed 200 chars")]
    public string Region { set; get; } = null!;
    
    [MaxLength(50, ErrorMessage = "Country name cannot exceed 200 chars")]
    public string Country { set; get; } = null!;
    
    [MaxLength(50, ErrorMessage = "City name cannot exceed 200 chars")]
    public string City { set; get; } = null!;
    
    [MaxLength(100, ErrorMessage = "Street address cannot exceed 200 chars")]
    public string? StreetAddress { set; get; }
}