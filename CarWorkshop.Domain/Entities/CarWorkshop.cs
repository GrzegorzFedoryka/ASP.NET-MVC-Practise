namespace CarWorkshop.Domain.Entities;

public class CarWorkshop
{
    private CarWorkshop()
    {

    }
    public int Id { get; init; }
    public string Name { get; private set; } = default!;
    public string? EncodedName { get { return Name.ToLower().Replace(" ", "-"); } private set { } }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string? About { get; private set; }
    public CarWorkshopContactDetails ContactDetails { get; private set; } = new();

    public static CarWorkshop Create(string name)
    {
        return new CarWorkshop()
        {
            Name = name,
        };
    }

    public CarWorkshop SetDescription(string? description) 
    {
        Description = description;
        return this; 
    }
    public CarWorkshop SetAbout(string? about)
    {
        About = about;
        return this;
    }
    public CarWorkshop SetPhoneNumber(string? phoneNumber)
    {
        ContactDetails.SetPhoneNumber(phoneNumber);
        return this;
    }
    public CarWorkshop SetStreet(string? street)
    {
        ContactDetails.SetStreet(street);
        return this;
    }
    public CarWorkshop SetCity(string? city)
    {
        ContactDetails.SetCity(city);
        return this;
    }
    public CarWorkshop SetPostalCode(string? postalCode)
    {
        ContactDetails.SetPostalCode(postalCode);
        return this;
    }
}
