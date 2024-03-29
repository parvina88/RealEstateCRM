﻿using MediatR;
using System.Text.Json.Serialization;

namespace RealEstate.Contract.Entrance;

public record UpdateEntranceRequest : IRequest<SingleEntranceResponse>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string Number { get; set; }
    public int NumberOfFloors { get; set; }
    public int NumberOfApartmentsPerFloor { get; set; }
    public double CeilingHeight { get; set; }
    public bool HasLift { get; set; }
    public Guid BuildingId { get; set; }
}