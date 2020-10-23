using MontyHallWeb.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallService.Contracts
{
    public interface IMontyHallSimulationService
    {
        MontyHallSimulationResultDto Run(MontyHallSimulationDto input);
    }
}
