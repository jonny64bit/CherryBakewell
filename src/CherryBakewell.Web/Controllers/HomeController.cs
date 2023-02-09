using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CherryBakewell.Base.Interfaces;
using CherryBakewell.Web.Models;

namespace CherryBakewell.Web.Controllers;

public class HomeController : ViewBaseController
{
    public HomeController(IService service) : base(service)
    {

    }

    public IActionResult Index()
    {
        //Adding routing values here just to easy of this test
        return RedirectToAction("Question", new { SchoolId = Guid.NewGuid(), Id = 1  });
    }

    [Route("/{schoolId}/maths/{id}")]
#pragma warning disable IDE0060 // Remove unused parameter
    public IActionResult Question(Guid schoolId, int id)
#pragma warning restore IDE0060 // Remove unused parameter
    {
        return View("Question");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
