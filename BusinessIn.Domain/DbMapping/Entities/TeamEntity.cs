using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessIn.Domain.DbMapping.Entities;

public class TeamEntity {
    public Guid Id { set; get; }
    
    
    [Required(ErrorMessage = "Team name is required"),
     MinLength(2, ErrorMessage = "Team name cannot be less than 2 chars"),
     MaxLength(50, ErrorMessage = "Team name cannot exceed 50 chars")]
    public string Name { set; get; } = null!;
    
    public Guid DepartmentId { set; get; }

    [ForeignKey(nameof(DepartmentId))]
    public DepartmentEntity Department { set; get; }
}