using Microsoft.AspNetCore.Mvc;
using CherryBakewell.Base.Interfaces;
using CherryBakewell.Database;

namespace CherryBakewell.Web.Controllers;

public class APIBaseController : ControllerBase
{
    public DAL Context => Service.Context;
    public readonly IService Service;

    public APIBaseController(IService service)
    {
        Service = service;
    }
}