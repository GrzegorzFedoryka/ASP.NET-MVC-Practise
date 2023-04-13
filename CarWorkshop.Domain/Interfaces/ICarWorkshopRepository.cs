﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Domain.Interfaces;

public interface ICarWorkshopRepository
{
    Task CreateAsync(Entities.CarWorkshop carWorkshop);
}
