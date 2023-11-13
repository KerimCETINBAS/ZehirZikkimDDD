using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ZehirZikkim.Api.Controllers;

[Route("[controller]")]
public class ZikkimsController : ApiController
{
 
    [Authorize]
    [HttpGet]
    public IActionResult ListZikkims() {

        return Ok(Array.Empty<string>());
    }
}
