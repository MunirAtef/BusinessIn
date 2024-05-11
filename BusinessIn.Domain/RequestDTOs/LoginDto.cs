namespace BusinessIn.Domain.RequestDTOs;

public class LoginDto {
    public string Email { set; get; } = null!;
    public string Password { set; get; } = null!;
}