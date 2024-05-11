// using Microsoft.AspNetCore.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
//
// namespace BusinessIn.Presentation.Controllers;
//
//
// public class ErrorsController : ControllerBase {
//     
//     [Route("error")]
//     public IActionResult Error() {
//         Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
//         return BadRequest(exception?.Message);
//     }
// }
