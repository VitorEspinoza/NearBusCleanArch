using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using NearBusCleanArch.Application.Validators;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.DTOs;

public class RouteCreateDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Departure Time is required")]
    [RegularExpression("^(?:[01]\\d|2[0-3]):[0-5]\\d$", ErrorMessage = "Invalid Departure Time. Enter a time between 00:00 and 23:59.")]
    public string DepartureTime { get; set; }
    
    [Required(ErrorMessage = "The Departure Days are required")]
    [ValidateDepartureDays(ErrorMessage = "Invalid Departure Days. The accepted days are: Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, and Sunday.")]
    public List<string> DepartureDays  { get; set; } 
    
    [DisplayName("Companies")]
    public int CompanieId { get; set; }
}