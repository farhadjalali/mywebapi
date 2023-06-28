using Findest.Api.Controllers;
using Xunit;
using Moq;

namespace Findest.Api.UnitTests.Controllers;

public class PersonControllerTests : ControllerTestsBase<PersonController>
{

    [Fact]
    public async Task GetAll_should_call_GetAllSortedByPlateAsync_onto_service()
    {

        //when
       await Controller.GetAllAsync(default);
    }
}