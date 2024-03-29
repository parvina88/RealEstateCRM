﻿using RealEstate.Domain.Enums;

namespace RealEstate.Domain.Entities;

public class Building
{
    public Guid Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public int YearOfConstruction { get; set; }
    public BuildingMaterial? BuildingMaterial { get; set; }
    public ApartmentClass? ApartmentClass { get; set; }

    public virtual ICollection<Entrance> Entrances { get; set; }
}