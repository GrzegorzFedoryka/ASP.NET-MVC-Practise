using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Repositories;

internal class CarWorkshopRepository : ICarWorkshopRepository, IRepositoryMarker
{
    private readonly CarWorkshopDbContext _context;

    public CarWorkshopRepository(CarWorkshopDbContext context)
	{
        _context = context;
    }

    public async Task CreateAsync(Domain.Entities.CarWorkshop carWorkshop)
    {
        _context.Add(carWorkshop);
        await _context.SaveChangesAsync();
    }
}
