namespace CarWorkshop.Domain.Entities;

public class CarWorkshop
{
    public int Id { get; init; }
    public string Name { get; private set; } = default!;
    public string EncodedName { get { return Name.ToLower().Replace(" ", "-"); } private set { } }
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public string? About { get; private set; }
    public CarWorkshopContactDetails ContactDetails { get; private set; } = default!;

    //public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
    public CarWorkshop SetName(string name)
    {
        Name = name;
        return this;
    }

    public CarWorkshop SetDescription(string description) 
    {
        Description = description;
        return this; 
    }

    public CarWorkshop SetDetails(CarWorkshopContactDetails details)
    {
        ContactDetails = details;
        return this;
    }
}
