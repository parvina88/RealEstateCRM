using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using RealEstate.Infrastructure.Identity;
using System.Reflection;

namespace RealEstate.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(builder);
        
        builder.Entity<IdentityUser>().ToTable("Users");
        builder.Entity<IdentityRole>().ToTable("Roles");
        builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
        builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
        builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
        builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");
        builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
    }

    public DbSet<Building> Buildings { get; set; }
    public DbSet<Entrance> Entrances { get; set; } = null!;
    public DbSet<Apartment> Apartments { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;
    public DbSet<Deal> Deals { get; set; } = null!;

}