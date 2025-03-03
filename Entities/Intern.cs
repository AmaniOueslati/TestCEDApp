namespace WebApi.Entities;

using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Intern
{
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string Team { get; set; }
 
}