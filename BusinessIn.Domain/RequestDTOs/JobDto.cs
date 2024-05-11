namespace BusinessIn.Domain.RequestDTOs;

public class JobDto {
    public string Title { set; get; } = null!;
    public string JobDescription { set; get; } = null!;
    public double MinSalary { set; get; }
    public double MaxSalary { set; get; }
}