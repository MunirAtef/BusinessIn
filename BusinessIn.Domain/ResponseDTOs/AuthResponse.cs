namespace BusinessIn.Domain.ResponseDTOs;

public class AuthResponse {
    public Guid Id { set; get; }
    public string Email { set; get; } = null!;
    public string FirstName { set; get; } = null!;
    public string LastName { set; get; } = null!;
    public string Roles { set; get; } = null!;
    public string AccessToken { set; get; } = null!;
    public string RefreshToken { set; get; } = null!;
    public string? ImageUrl { set; get; }
    public float Salary { set; get; }
    
    
    public Guid? SupervisorId { set; get; }
    public Guid? TeamId { set; get; }
    public Guid? DepartmentId { set; get; }
    public Guid? LocationId { set; get; }
    public DateOnly HiringDate { set; get; }
    public DateTime CreatedAt { set; get; }
}