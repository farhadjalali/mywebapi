using Microsoft.EntityFrameworkCore;
using Findest.Core.Dtos;
using Finest.Core.Models;
using Findest.Core.Extensions;

namespace Findest.Core.Repositories;

public interface IPersonRepository
{
    Task<List<PersonDto>> GetAllAsync(CancellationToken cancellationToken);
    Task<PersonDto> GetByIdAsync(int id, CancellationToken cancellationToken);
}


public class EmployeeRepository : RepositoryBase<Person>, IPersonRepository
{
    public EmployeeRepository(EmployeesContext dbContext) : base(dbContext)
    {

    }

    public async Task<List<PersonDto>> GetAllAsync(CancellationToken cancellationToken)
    {
        var persons = await DbContext.Persons
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return persons.Select(PersonExtensions.MapToDto).ToList();
    }

    public async Task<PersonDto> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        var emp = await DbContext.Persons
            .AsNoTracking()
            .SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
        if (emp == null)
        {
            return null!;
        }

        return emp.MapToDto();
    }
}