namespace BusinessIn.Domain.RequestDTOs;

public class LocationDto {
    public string PostalCode { set; get; } = null!;
    public string Region { set; get; } = null!;
    public string Country { set; get; } = null!;
    public string City { set; get; } = null!;
    public string? StreetAddress { set; get; }
}