using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Infrastructure.Configuration;

public class CarWorkshopConfiguration : IEntityTypeConfiguration<Domain.Entities.CarWorkshop>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Domain.Entities.CarWorkshop> builder)
    {
        builder
            .Property(b => b.EncodedName)
            .UsePropertyAccessMode(PropertyAccessMode.Property);
    }
}
