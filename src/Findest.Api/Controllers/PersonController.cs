namespace MyWebApi.Controllers;

using Microsoft.AspNetCore.Mvc;
using Finest.Core.Models;

[ApiController]
[Route("api/persons")]
public class PersonController : ControllerBase
{
    private readonly ILogger<PersonController> _logger;

    public PersonController(ILogger<PersonController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetPerson")]
    public IEnumerable<Person> Get()
    {
        _logger.LogInformation("GetPerson called");
        return Enumerable.Range(1, 5).Select(index => new Person
        {
            Id = index,
            FirstName = "John",
            LastName = "Doe",
            DateOfBirth = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
        })
        .ToArray();
    }
}
