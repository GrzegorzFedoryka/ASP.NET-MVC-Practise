using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Dtos;

public record CarWorkshopDto(
    [Required] string Name, 
    string? Description, 
    string? About, 
    [StringLength(12, MinimumLength = 8)] string? PhoneNumber,
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
