using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using GrpcClient.Models;
using GrpcClient.Rpc;

namespace GrpcClient.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IGreetClient _greetClient;


    public HomeController(ILogger<HomeController> logger, IGreetClient greetClient)
    {
        _logger = logger;
        _greetClient = greetClient;
    }


    public async Task<IActionResult> Index()
    {
        var result = await _greetClient.SendSayHello();
        return Ok(result);
    }
    
    
    public async Task<IActionResult> Moeen()
    {
        var result = await _greetClient.SendSayGoodbye();
        return Ok(result);
    }
}