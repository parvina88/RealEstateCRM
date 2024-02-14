using Microsoft.EntityFrameworkCore;
using RealEstate.Domain.Entities;

namespace RealEstate.Application.Data;

public interface IApplicationDbContext
{
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Entrance> Entrances {get; set; }
    public DbSet<Apartment> Apartments { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}