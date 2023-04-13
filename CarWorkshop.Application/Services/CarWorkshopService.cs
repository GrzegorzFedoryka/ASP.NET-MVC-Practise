using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services;

public interface ICarWorkshopService
{
    Task CreateAsync(Domain.Entities.CarWorkshop carWorkshop);
}

public class CarWorkshopService : ICarWorkshopService, IServiceMarker
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;

    public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
    {
        _carWorkshopRepository = carWorkshopRepository;
    }
    public async Task CreateAsync(Domain.Entities.CarWorkshop carWorkshop)
    {
        await _carWorkshopRepository.CreateAsync(carWorkshop);
    }
}
