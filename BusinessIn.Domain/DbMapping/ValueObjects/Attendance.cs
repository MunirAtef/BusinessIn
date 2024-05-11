using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BusinessIn.Domain.DbMapping.Entities;

namespace BusinessIn.Domain.DbMapping.ValueObjects;


public class Attendance {
    public Guid EmployeeId { set; get; }
    public DateOnly Date { set; get; }
    
    [MaxLength(50, ErrorMessage = "Attendance type cannot exceed 50 chars")]
    public string AttendanceType { set; get; } = null!;
    
    [ForeignKey(nameof(EmployeeId))]
    public EmployeeEntity Employee { set; get; }
}