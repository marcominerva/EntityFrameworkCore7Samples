using System.ComponentModel.DataAnnotations;

namespace MappingSamples.DataAccessLayer.Entities;

public class Student : Person
{
    [Required]
    [MaxLength(6)]
    public string IdentificationNumber { get; set; }
}
