using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.DTOs;

public class RouteDTO
{
    public int Id { get; set; }
    [Required(ErrorMessage = "The Name is required")]
    [MaxLength(200)]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "The Departure Time is required")]
    public string DepartureTime { get; set; }
    
    [Required(ErrorMessage = "The Departure Days are required")]
    public DayOfWeek[] DepartureDays  { get; set; } 
    
    [JsonIgnore]
    public Companie Companie { get; set; }

    [DisplayName("Companies")]
    public int CompanieId { get; set; }
}