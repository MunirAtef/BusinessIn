using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessIn.Domain.DbMapping.Entities;

public class DepartmentEntity {
    public Guid Id { set; get; }
    
    [Required(ErrorMessage = "Department name is required"), 
     MinLength(2, ErrorMessage = "Department name cannot be less than 2 chars"),
     MaxLength(50, ErrorMessage = "Department name cannot exceed 50 chars")]
    public string Name { set; get; } = null!;
    
    [Required(ErrorMessage = "LocationId is required")]
    public Guid LocationId { set; get; }
    
    [ForeignKey(nameof(LocationId))]
    public LocationEntity Location { set; get; }
    
    // public ICollection<TeamEntity> Teams { set; get; }
    // public ICollection<TeamEntity> Employees { set; get; }
    // public ICollection<GroupMessageEntity> Messages { set; get; }
}