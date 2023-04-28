using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormSubmission.Models;

namespace FormSubmission.Controllers;

public class HomeController : Controller
{
    static Registration? NewRegistration;

    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet("/")]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost("/addUser")]
    public IActionResult addUser(Registration newRegistration)
    {    
        if (!ModelState.IsValid)
        {
            return View("Index");
        }
        else
        {
            NewRegistration = newRegistration;
            return RedirectToAction("Results");
        }
    }

    [HttpGet("/results")]
    public IActionResult Results()
    {
        return View("Results", NewRegistration);
    }

    [HttpGet("{**path}")]   
    public RedirectToActionResult Unknown()
    {
        return RedirectToAction("Index");
    }
    [HttpGet("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
