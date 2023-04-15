using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Dtos;

public record CarWorkshopDto(
    string Name, 
    string? Description, 
    string? About, 
    string? PhoneNumber,
    string? Street,
    string? City,
    string? PostalCode)
{
    public Domain.Entities.CarWorkshop ToCarWorkshop()
    {
        var carWorkshop = Domain.Entities.CarWorkshop.Create(Name);

        carWorkshop
            .SetDescription(Description)
            .SetAbout(About)
            .SetPhoneNumber(PhoneNumber)
            .SetCity(City)
            .SetPostalCode(PostalCode)
            .SetStreet(Street);

        return carWorkshop;
    }
}
