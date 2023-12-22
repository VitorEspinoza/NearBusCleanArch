using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Application.DTOs;

public class RouteDTO
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string DepartureTime { get; set; }
    
    public List<string> DepartureDays  { get; set; } 
    
    [JsonIgnore]
    public Companie Companie { get; set; }

    [DisplayName("Companies")]
    public int CompanieId { get; set; }
}