﻿using System.ComponentModel.DataAnnotations;

namespace NearBusCleanArch.Application.DTOs;

public class CompanieDTO
{
    [Required(ErrorMessage = "The Name is required")]
    [MinLength(2)]
    [MaxLength(100)]
    public string Name { get;  set; }
 
    [Required(ErrorMessage = "The Document is required")]
    [StringLength(14)]
    public string Document { get;  set; }
}