using MontyHallWeb.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallService.Contracts
{
    public interface IMontyHallSimulationService
    {

        /// <summary>
        /// Runing the Simulation.
        /// </summary>
        /// <param name="input">Input Paramertes</param>
        /// <returns>Simulation Result</returns>
        MontyHallSimulationResultDto Run(MontyHallSimulationDto input);
    }
}
