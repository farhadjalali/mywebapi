using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Finest.Core.Models;
[Table("persons")]
public class Person
{
    [Key]
    [Column("id", TypeName = "serial(4)")]
    public int Id { get; set; }

    [Required]
    [Column("first_name")]
    [StringLength(14)]
    public string? FirstName { get; set; }

    [Required]
    [Column("last_name")]
    [StringLength(16)]
    public string? LastName { get; set; }

    [Required]
    [Column("birth_date", TypeName = "date")]
    public DateOnly DateOfBirth { get; set; }
}