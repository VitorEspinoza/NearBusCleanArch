using System.ComponentModel.DataAnnotations;

namespace NearBusCleanArch.Application.DTOs;

public class AdressDTO
{
    [Required(ErrorMessage = "The street is required")]
    [MaxLength(100)]
    public string Street { get; set; }
    
    [Required(ErrorMessage = "The street is required")]
    [MaxLength(40)]
    public string Neighborhood { get; set; }
    
    [Required(ErrorMessage = "The street is required")]
    [MaxLength(40)]
    public string City { get; set; }
    
    [Required(ErrorMessage = "The street is required")]
    [MaxLength(30)]
    public string State { get; set; }
    
    [Required(ErrorMessage = "The street is required")]
    [MaxLength(5)]
    public string Number { get; set; }
    
    [Required(ErrorMessage = "The street is required")]
    [StringLength(8)]
    public string ZipCode {  get; set; }
}