using CarWorkshop.Application.Dtos;
using CarWorkshop.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services;

public interface ICarWorkshopService
{
    Task CreateAsync(CarWorkshopDto carWorkshopDto);
    Task<IEnumerable<CarWorkshopDto>> GetAllAsync();
}

public class CarWorkshopService : ICarWorkshopService, IServiceMarker
{
    private readonly ICarWorkshopRepository _carWorkshopRepository;

    public CarWorkshopService(ICarWorkshopRepository carWorkshopRepository)
    {
        _carWorkshopRepository = carWorkshopRepository;
    }
    public async Task CreateAsync(CarWorkshopDto carWorkshopDto)
    {
        await _carWorkshopRepository.CreateAsync(carWorkshopDto.ToCarWorkshop());
    }

    public async Task<IEnumerable<CarWorkshopDto>> GetAllAsync()
    {
        var carWorkshops = await _carWorkshopRepository.GetAllAsync();

        return carWorkshops.Select(c => CarWorkshopDto.FromCarWorkshop(c));
    }
}
