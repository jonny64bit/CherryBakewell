using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CherryBakewell.Base.Interfaces;
using PhoneBook.Web.Models;

namespace CherryBakewell.Web.Controllers;

public class HomeController : ViewBaseController
{
    public HomeController(IService service) : base(service)
    {
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
    }
}