using CherryBakewell.Web.Controllers;
using CherryBakewell.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace CherryBakewell.Web.Tests.Controllers;

/// <summary>
/// This just provides an example.
/// If this was for a production scenario i would aim for 100% coverage.
/// </summary>
public class DataControllerTests : BaseTest
{
    [Fact]
    public async Task AddCalculation_Basic()
    {
        // arrange
        var controller = Mocker.CreateInstance<DataController>();

        // act
        var result = await controller.AddCalculation(new AddCalculation());

        // assert
        result.ShouldBeAssignableTo<OkResult>();
    }
}
