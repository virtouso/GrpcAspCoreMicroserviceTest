using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TestCustomAuth.Controllers;

[ApiController]
public class AuthController : Controller
{
    private readonly IConfiguration _configuration;


    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult AuthenticateUser(string name, string email)
    {
        // var rsa = RSA.Create();
        //
        // rsa.Encrypt();
        //
        // var token = JwtBuilder.Create()
        //     .WithAlgorithm(new RS256Algorithm(new RSACryptoServiceProvider())),
        //     
        //     .AddClaim("exp", DateTimeOffset.UtcNow.AddHours(1).ToUnixTimeSeconds())
        //     .AddClaim("claim1", 0)
        //     .AddClaim("claim2", "claim2-value")
        //     .Encode();
        
        
    }
    
   
   
}