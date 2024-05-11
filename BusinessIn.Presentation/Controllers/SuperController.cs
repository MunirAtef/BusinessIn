using System.Security.Claims;
using BusinessIn.Presentation.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BusinessIn.Presentation.Controllers;

// [ErrorHandlingFilter]
[Authorize]
[ApiController]
[Route("api/v1/[controller]")]
public abstract class SuperController : ControllerBase {
    protected string GetUserId() =>
        (HttpContext.User.Identity as ClaimsIdentity)?.Claims.FirstOrDefault(claim =>
            claim.Type == ClaimTypes.NameIdentifier)?.Value!;

    // protected string? GetQueryParameter(string key) {
    //     HttpContext.Request.Query.TryGetValue(key, out var value);
    //     var result = value.ToString();
    //     return result == "" ? null : result;
    // }
}