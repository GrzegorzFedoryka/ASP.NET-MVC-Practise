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
                new Domain.Entities.CarWorkshop()
                    .SetName("U Janka")
                    .SetDescription("Najtańszy workshop")
                    .SetDetails(new CarWorkshopContactDetails
                    {
                        City = "Wrocław",
                        PhoneNumber = "+48 555 444 333",
                        PostalCode = "51-317",
                        Street = "Bierutowska 51"
                    })
                    );

            await _dbContext.SaveChangesAsync();
        }
    }
}
