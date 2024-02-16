using Microsoft.EntityFrameworkCore;
using RealEstate.Application.Data;

namespace RealEstate.Infrastructure.Data;

public class ApplicationDbInitializer : IApplicationDbInitializer
{
    private readonly ApplicationDbContext _context;

    public ApplicationDbInitializer(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public void Initialize()
    {
        if (_context.Database.IsRelational())
        {
            _context.Database.Migrate();
        }
    }
}