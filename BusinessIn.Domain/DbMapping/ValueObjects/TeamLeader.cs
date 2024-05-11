using System.ComponentModel.DataAnnotations.Schema;
using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Domain.DbMapping.ValueObjects;

public class TeamLeader {
    public Guid TeamId { set; get; }
    public Guid LeaderId { set; get; }
    public DateOnly StartDate { set; get; }
    public DateOnly? EndDate { set; get; }
    
    [ForeignKey(nameof(TeamId))]
    public TeamEntity Team { set; get; }
    
    [ForeignKey(nameof(LeaderId))]
    public EmployeeEntity Leader { set; get; }
}