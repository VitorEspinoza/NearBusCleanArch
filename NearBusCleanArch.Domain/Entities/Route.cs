using System;
using System.Collections.Generic;

namespace NearBusCleanArch.Domain.Entities;

public class Route
{
    public string name { get; set; }
    public DateTime DepartureTime { get; set; }

    public int CompanieId { get; set; }
    public Companie Companie { get; set; }

    public ICollection<Employee> Employees { get; } = new List<Employee>();

}