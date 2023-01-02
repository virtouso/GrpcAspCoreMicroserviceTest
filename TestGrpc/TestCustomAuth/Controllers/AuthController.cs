using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Jose;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TestCustomAuth.Filters;

namespace TestCustomAuth.Controllers;

[Controller]
public class AuthController : Controller
{
    private readonly IConfiguration _configuration;


    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }



    //[CustomAuthorize]
    [HttpGet]
    public IActionResult AuthenticateUser(string name, string email)
    {
        
        var payload = new Dictionary<string, object>() { { "Email", email }, { "UserName", name } };
        var secretKey = Encoding.UTF8.GetBytes( _configuration.GetSection("AuthSecret").Value); // new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };
        TokenValidationParameters parameters = new TokenValidationParameters { RequireExpirationTime = true, ClockSkew = new TimeSpan(0, 5, 0), };
        string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
        return Ok(token);
        

    }
}