using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities;

public class CarWorkshopContactDetails
{
    internal CarWorkshopContactDetails()
    {

    }
    public string? PhoneNumber { get; private set; }
    public string? Street { get; private set; }
    public string? City { get; private set; }
    public string? PostalCode { get; private set; }

    public void SetPhoneNumber(string? phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }
    public void SetStreet(string? street)
    {
        Street = street;
    }
    public void SetCity(string? city)
    {
        City = city;
    }
    public void SetPostalCode(string? postalCode)
    {
        PostalCode = postalCode;
    }

}
