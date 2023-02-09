using CherryBakewell.Base.Interfaces;
using CherryBakewell.Database.Models;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.Web.Models;

namespace CherryBakewell.Web.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController : APIBaseController
{
    public DataController(IService service) : base(service)
    {
    }

    [HttpPost("add-calculation")]
    public async Task<OkResult> AddCalculation([FromBody] AddCalculation model)
    {
        var calculation = Service.Mapper.Map<Calculation>(model);
        await Service.Calculation.AddAsync(calculation);
        return Ok();
    }
}
