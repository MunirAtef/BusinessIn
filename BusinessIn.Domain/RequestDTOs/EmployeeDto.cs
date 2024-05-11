
namespace BusinessIn.Domain.RequestDTOs;

public class EmployeeDto {
    public string Email { set; get; } = null!;
    public string Password { set; get; } = null!;
    public string FirstName { set; get; } = null!;
    public string LastName { set; get; } = null!;
    public string Roles { set; get; } = "emp";
    public string? ImageUrl { set; get; }
    public float Salary { set; get; }
    public Guid? SupervisorId { set; get; }
    public Guid? TeamId { set; get; }
    public Guid? DepartmentId { set; get; }
    public Guid? LocationId { set; get; }
    // public DateOnly HiringDate { set; get; }
}