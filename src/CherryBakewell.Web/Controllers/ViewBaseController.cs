using Microsoft.AspNetCore.Mvc;
using CherryBakewell.Base.Interfaces;
using CherryBakewell.Database;
using CherryBakewell.Web.Models;

namespace CherryBakewell.Web.Controllers;

public class ViewBaseController : Controller
{
    public DAL Context => Service.Context;
    public readonly IService Service;

    public ViewBaseController(IService service)
    {
        Service = service;
    }

    protected JsonResult JsonOK() => Json(new GeneralJsonMessage<string> { Result = "OK", Detail = "" });
    protected JsonResult JsonErrorMessage(string message) => Json(new GeneralJsonMessage<string> {Result = "FAIL", Detail = message});
}
