using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessIn.Domain.DbMapping.Entities;

public class GroupMessageEntity {
    public Guid Id { set; get; }
    public Guid SenderId { set; get; }
    public Guid? TeamId { set; get; }
    public Guid? DepartmentId { set; get; }
    public Guid? LocationId { set; get; }
    
    public string Content { set; get; } = null!;
    
    // ContentTypes: txt - png - jpg - mp3 - mp4
    [MaxLength(10, ErrorMessage = "Content type cannot exceed 10 chars")]
    public string ContentType { set; get; } = "txt";
    
    
    [ForeignKey(nameof(SenderId))]
    public EmployeeEntity? Sender { set; get; }
    
    [ForeignKey(nameof(TeamId))]
    public TeamEntity? Team { set; get; }
    
    [ForeignKey(nameof(DepartmentId))]
    public DepartmentEntity? Department { set; get; }
    
    [ForeignKey(nameof(LocationId))]
    public LocationEntity? Location { set; get; }
}

