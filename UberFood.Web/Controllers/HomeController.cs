using Microsoft.AspNetCore.Mvc;

namespace UberFood.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
