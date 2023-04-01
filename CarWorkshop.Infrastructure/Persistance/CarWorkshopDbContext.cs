using CarWorkshop.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Persistance;

public class CarWorkshopDbContext : DbContext
{
    public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; }

    private CarWorkshopDbContext(){ }

    public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Domain.Entities.CarWorkshop>()
            .OwnsOne(e => e.ContactDetails);
    }
}
