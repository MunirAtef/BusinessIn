using System.ComponentModel.DataAnnotations.Schema;
using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Domain.DbMapping.ValueObjects;

public class DepartmentManager {
    public Guid DepartmentId { set; get; }
    public Guid ManagerId { set; get; }
    public DateOnly StartDate { set; get; }
    public DateOnly EndDate { set; get; }
    
    [ForeignKey(nameof(DepartmentId))]
    public DepartmentEntity Department { set; get; }
    
    [ForeignKey(nameof(ManagerId))]
    public EmployeeEntity Manager { set; get; }
}