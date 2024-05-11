using BusinessIn.Application.Exceptions.Common;

namespace BusinessIn.Application.Exceptions.Auth;

public class DuplicateEmailException : BnException {
    public DuplicateEmailException() {
        SetTitle(nameof(DuplicateEmailException));
        SetDetails("Employee with this email already exists");
        SetStatusCode(409);
    }
}