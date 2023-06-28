using Microsoft.AspNetCore.Mvc;
using Findest.Core.Models;
using Findest.Core.Dtos;
using Findest.Core.Repositories;

namespace Findest.Api.Controllers;
[Route("[controller]")]
public class PersonController : ApiControllerBase
{
    private readonly IPersonRepository _personRepository;

    public PersonController(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    [HttpGet(Name = "GetPerson")]
    [ProducesResponseType(typeof(IEnumerable<PersonDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllAsync(
            CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await _personRepository.GetAllAsync(cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
