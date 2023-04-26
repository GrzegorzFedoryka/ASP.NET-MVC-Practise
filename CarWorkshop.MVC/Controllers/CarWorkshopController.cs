using CarWorkshop.Application.Dtos;
using CarWorkshop.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarWorkshop.MVC.Controllers;

public class CarWorkshopController : Controller
{
    private readonly ICarWorkshopService _carWorkshopService;

    public CarWorkshopController(ICarWorkshopService carWorkshopService)
    {
        _carWorkshopService = carWorkshopService;
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(CarWorkshopDto carWorkshopDto)
    {
        if(!ModelState.IsValid) 
        { 
            return View(carWorkshopDto);
        }
        await _carWorkshopService.CreateAsync(carWorkshopDto);

        return RedirectToAction(nameof(Create)); //TODO: refactor
    }
    public async Task<IActionResult> Index()
    {
        var carWorkshops = await _carWorkshopService.GetAllAsync();

        return View(carWorkshops);
    }
}