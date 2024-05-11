
namespace BusinessIn.Domain.RequestDTOs;

public class DepartmentDto {
    public string Name { set; get; } = null!;
    public Guid LocationId { set; get; }
}