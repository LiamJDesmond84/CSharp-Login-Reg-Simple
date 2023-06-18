using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CSharp_Login_Reg_Simple.Models;
using Microsoft.AspNetCore.Http;

namespace CSharp_Login_Reg_Simple.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public IActionResult RegisterUser(RegUser regUser)

    {
        var postedValues = HttpContext.Request.Query["other"].ToString();
        HttpContext.Session.SetString("OtherUser", postedValues);

        if (ModelState.IsValid)
        {
            return RedirectToAction("SuccessPage");
        }

        else
        {
            return View("Index");
        }
    }

    public IActionResult Login(LogUser logUser)
    {
        if (ModelState.IsValid)
        {
            return RedirectToAction("SuccessPage");
        }

        else
        {
            return View("Index");
        }
    }

    public IActionResult SuccessPage()
    {
        string LocalVariable = HttpContext.Session.GetString("OtherUser");

        return View(LocalVariable);
    }
}
