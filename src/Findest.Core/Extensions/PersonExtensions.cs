using Findest.Core.Dtos;
using Findest.Core.Models;

namespace Findest.Core.Extensions;

internal static class PersonExtensions
{
    public static PersonDto MapToDto(this Person source)
    {
        return new PersonDto
        {
            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName,
            DateOfBirth = source.DateOfBirth,
        };
    }
}