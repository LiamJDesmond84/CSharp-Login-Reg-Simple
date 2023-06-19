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

        // USING EXTENSION METHOD FROM SessionExtensions Utility Class
        //List<object> NewList = new List<object>();

        //HttpContext.Session.SetObjectAsJson("TheList", NewList);

        HttpContext.Session.SetObjectAsJson("User", regUser);

        // Notice that we specify the type ( List ) on retrieval
        List<object> Retrieve = HttpContext.Session.GetObjectFromJson<List<object>>("TheList");




        var postedValues = HttpContext.Request.Form["OtherUser"].ToString();
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
        ViewBag.OtherUser = HttpContext.Session.GetString("OtherUser");

        return View();
    }


    //// *Inside controller methods*
    //// To store a string in session we use ".SetString"
    //// The first string passed is the key and the second is the value we want to retrieve later
    //      HttpContext.Session.SetString("UserName", "Samantha");
    //// To retrieve a string from session we use ".GetString"
    //      string LocalVariable = HttpContext.Session.GetString("UserName");

    //// To store an int in session we use ".SetInt32"
    //      HttpContext.Session.SetInt32("UserAge", 28);
    //// To retrieve an int from session we use ".GetInt32"
    //      int? IntVariable = HttpContext.Session.GetInt32("UserAge");

    // We can clear our session with the Clear method:

    // HttpContext.Session.Clear();
}
