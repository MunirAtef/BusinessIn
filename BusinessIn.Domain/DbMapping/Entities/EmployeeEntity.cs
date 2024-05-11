using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessIn.Domain.Enums;
using Toolbelt.ComponentModel.DataAnnotations.Schema.V5;

namespace BusinessIn.Domain.DbMapping.Entities;


public class EmployeeEntity {
    public Guid Id { set; get; }

    [Required(ErrorMessage = "Email is required")]
    [MaxLength(100, ErrorMessage = "Email cannot exceed 100 chars")]
    [EmailAddress(ErrorMessage = "Wrong email format")]
    [IndexColumn(IsUnique = true)]
    public string Email { set; get; } = null!;

    [Required(ErrorMessage = "Password is required")]
    [MaxLength(100, ErrorMessage = "Password cannot exceed 50 chars")]
    public string HashedPassword { set; get; } = null!;
    
    public AccountStatus Status { set; get; } = AccountStatus.Created;
    
    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name cannot be less than 2 chars")]
    [MaxLength(50, ErrorMessage = "First name cannot exceed 50 chars")]
    public string FirstName { set; get; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name cannot be less than 2 chars")]
    [MaxLength(50, ErrorMessage = "Last name cannot exceed 50 chars")]
    public string LastName { set; get; } = null!;

    [MaxLength(20, ErrorMessage = "Roles cannot exceed 20 chars")]
    public string Roles { set; get; } = "emp";

    [MaxLength(200, ErrorMessage = "Image URL cannot be less than 2 chars")]
    public string? ImageUrl { set; get; }

    public float Salary { set; get; }

    public Guid? SupervisorId { set; get; }
    public Guid? TeamId { set; get; }
    public Guid? DepartmentId { set; get; }
    public Guid? LocationId { set; get; }
    public DateOnly HiringDate { set; get; }
    public DateTime CreatedAt { set; get; }

    [ForeignKey(nameof(SupervisorId))]
    public EmployeeEntity? Supervisor { set; get; }

    [ForeignKey(nameof(TeamId))]
    public TeamEntity? Team { set; get; }

    [ForeignKey(nameof(DepartmentId))]
    public DepartmentEntity? Department { set; get; }

    [ForeignKey(nameof(LocationId))]
    public LocationEntity? Location { set; get; }
}
