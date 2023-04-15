using CarWorkshop.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Seeders;

public class CarWorkshopSeeder
{
    private readonly CarWorkshopDbContext _dbContext;

    public CarWorkshopSeeder(CarWorkshopDbContext dbContext)
	{
        _dbContext = dbContext;
    }

    public async Task SeedAsync()
    {
        if(await _dbContext.Database.CanConnectAsync() 
            && !await _dbContext.CarWorkshops.AnyAsync())
        {
            await _dbContext.CarWorkshops.AddRangeAsync(
                Domain.Entities.CarWorkshop.Create("U Janka")
                    .SetDescription("Najtańszy workshop")
                    .SetStreet("Bierutowska 51")
                    .SetPostalCode("51-307")
                    .SetCity("Wrocław")
                    .SetPhoneNumber("+48 555 444 333")
                    );

            await _dbContext.SaveChangesAsync();
        }
    }
}
