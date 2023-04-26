using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Dtos;

public record class CarWorkshopDto(
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

    public static CarWorkshopDto FromCarWorkshop(Domain.Entities.CarWorkshop carWorkshop)
    {
        return new CarWorkshopDto(
            carWorkshop.Name,
            carWorkshop.Description,
            carWorkshop.About,
            carWorkshop.ContactDetails.PhoneNumber,
            carWorkshop.ContactDetails.Street,
            carWorkshop.ContactDetails.City,
            carWorkshop.ContactDetails.PostalCode);
    }
}

public class CarWorkshopDtoValidator : AbstractValidator<CarWorkshopDto>
{
    public CarWorkshopDtoValidator()
    {
        RuleFor(cw => cw.Name).NotEmpty();

        RuleFor(cw => cw.PhoneNumber)
            .NotEmpty()
            .MinimumLength(8)
            .MaximumLength(12);
    }
}
