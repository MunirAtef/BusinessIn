using System.ComponentModel.DataAnnotations.Schema;
using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Domain.DbMapping.ValueObjects;

public class JobHistory {
    public Guid EmployeeId { set; get; }
    public Guid JobId { set; get; }

    public DateOnly StartDate;
    public DateOnly EndDate;

    [ForeignKey(nameof(EmployeeId))]
    public EmployeeEntity Employee { set; get; }
    
    [ForeignKey(nameof(JobId))]
    public JobEntity Job { set; get; }
}