using BusinessIn.Application.AbstractRepositories;
using BusinessIn.Application.Common.Authentication;
using BusinessIn.Application.Common.Validators;
using BusinessIn.Domain.DbMapping.Entities;
using BusinessIn.Domain.Enums;
using BusinessIn.Domain.RequestDTOs;
using BusinessIn.Domain.ResponseDTOs;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

[AllowAnonymous]
public class AuthController(IAuthRepository authRepository, IJwtTokenGenerator tokenGenerator) : SuperController {
    // [HttpPost("token")]
    // public IActionResult GetToken(EmployeeDto employee) {
    //     var employeeEntity = employee.Adapt<EmployeeEntity>();
    //     employeeEntity.Id = Guid.NewGuid();
    //     var token = tokenGenerator.CreateToken(employeeEntity);
    //
    //     return Ok(token);
    // }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDto login) {
        var validation = await new LoginDtoValidator().ValidateAsync(login);
        if (!validation.IsValid) return BadRequest(validation.Errors);

        var employee = await authRepository.Login(login.Email, login.Password);
        if (employee == null) return Unauthorized();

        var accessToken = tokenGenerator.CreateToken(employee);
        var refreshToken = tokenGenerator.CreateToken(employee, TokenType.RefreshToken);
        var response = employee.Adapt<AuthResponse>();
        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;
        return Ok(response);
    }

    [HttpPost("active-account")]
    public async Task<IActionResult> ActiveAccount(ActiveAccountDto active) {
        var validation = await new ActiveAccountDtoValidator().ValidateAsync(active);
        if (!validation.IsValid) return BadRequest(validation.Errors);

        var employee = await authRepository.ActiveAccount(active.Email, active.Password, active.NewPassword);
        if (employee == null) return Unauthorized();

        var accessToken = tokenGenerator.CreateToken(employee);
        var refreshToken = tokenGenerator.CreateToken(employee, TokenType.RefreshToken);
        var response = employee.Adapt<AuthResponse>();
        response.AccessToken = accessToken;
        response.RefreshToken = refreshToken;
        return Ok(response);
    }
}