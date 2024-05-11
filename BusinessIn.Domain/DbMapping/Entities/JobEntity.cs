using System.ComponentModel.DataAnnotations;

namespace BusinessIn.Domain.DbMapping.Entities;

public class JobEntity {
    public Guid Id { set; get; }
    
    [MaxLength(50, ErrorMessage = "Job title cannot exceed 50 chars")]
    public string Title { set; get; } = null!;
    
    [MaxLength(200, ErrorMessage = "Job description cannot exceed 200 chars")]
    public string JobDescription { set; get; } = null!;
    public double MinSalary { set; get; }
    public double MaxSalary { set; get; }
}
