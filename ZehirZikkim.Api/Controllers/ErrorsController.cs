
using Microsoft.AspNetCore.Mvc;

namespace ZehirZikkim.Api.Controllers;

public class ErrorsController: ControllerBase {
    [Route("/error")]
    public IActionResult Error() {
        return Problem();
    }

}