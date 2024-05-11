using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.Enums;

namespace BusinessIn.Application.Common.Authentication;

public interface IJwtTokenGenerator {
    public string CreateToken(EmployeeEntity employee, TokenType type = TokenType.AccessToken);
}