using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Entities;

public class CarWorkshop
{
    public required int Id { get; init;  }
    public string Name { get; private set; } = default!;
    public string EncodedName { get; private set; } = default!;
    public string? Description { get; private set; }
    public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
    public CarWorkshopContactDetails ContactDetails { get; private set; } = default!;

    public void EncodeName() => EncodedName = Name.ToLower().Replace(" ", "-");
}
