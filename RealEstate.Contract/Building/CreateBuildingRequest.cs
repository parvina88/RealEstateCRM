﻿using RealEstate.Domain.Enums;

namespace RealEstate.Contract.Building;

public class CreateBuildingRequest
{
    public string Name { get; set; }
    public string Address { get; set; }
    public int YearOfConstruction { get; set; }
    public BuildingMaterial? BuildingMaterial { get; set; }

    public ApartmentClass? ApartmentClass { get; set; }

    //public virtual ICollection<Entrance> Entrances { get; set; }
}