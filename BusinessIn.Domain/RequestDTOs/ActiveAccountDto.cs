namespace BusinessIn.Domain.RequestDTOs;

public class ActiveAccountDto {
    public string Email { set; get; } = null!;
    public string Password { set; get; } = null!;
    public string NewPassword { set; get; } = null!;
}