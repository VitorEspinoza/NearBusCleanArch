using System.ComponentModel.DataAnnotations;

namespace NearBusCleanArch.Application.DTOs;

public class RouteDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Departure Time is required")]
    public TimeSpan DepartureTime { get; set; }
    
    [Required(ErrorMessage = "The Departure Days are required")]
    public DayOfWeek[] DepartureDays  { get; set; } 
}