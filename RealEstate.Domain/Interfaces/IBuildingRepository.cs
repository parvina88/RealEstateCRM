﻿using RealEstate.Domain.Entities;

namespace RealEstate.Domain.Interfaces;

public interface IBuildingRepository
{
    Task<bool> CreateAsync(Building building);
    Task<Building?> GetAsync(Guid id);
    Task<IEnumerable<Building>> GetAllAsync();
    Task<bool> UpdateAsync(Building building);
    Task<bool> DeleteAsync(Building building);
}