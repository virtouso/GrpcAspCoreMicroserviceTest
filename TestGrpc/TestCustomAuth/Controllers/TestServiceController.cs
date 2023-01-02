using Jose;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestCustomAuth.Filters;

namespace TestCustomAuth.Controllers;

[Controller]
public class TestServiceController : Controller
{
    [CustomAuthorize]
    [HttpGet]
    public IActionResult ChangeHero()
    {
        var name = HttpContext.Items["UserName"];
        var email = HttpContext.Items["Email"];
        return Ok((name, email));
    }
}