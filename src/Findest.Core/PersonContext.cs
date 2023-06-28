using Findest.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Findest.Core;
public class EmployeesContext : DbContext
{
    public EmployeesContext(DbContextOptions<EmployeesContext> options)
        : base(options)
    {
    }

    public DbSet<Person> Persons { get; set; } = null!;
}
