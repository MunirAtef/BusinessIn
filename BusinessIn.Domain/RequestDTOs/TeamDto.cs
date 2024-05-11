
namespace BusinessIn.Domain.RequestDTOs;

public class TeamDto {
    public string Name { set; get; } = null!;
    public Guid DepartmentId { set; get; }
    public Guid ManagerId { set; get; }
}