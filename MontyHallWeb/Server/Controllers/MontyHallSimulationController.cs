using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MontyHallService.Contracts;
using MontyHallWeb.Shared;

namespace MontyHallWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MontyHallSimulationController : ControllerBase
    {
        private readonly IMontyHallSimulationService _simulationService;

        public MontyHallSimulationController(IMontyHallSimulationService simulationService)
        {
            _simulationService = simulationService ?? throw new ArgumentNullException(nameof(simulationService));
        }

        public IActionResult Post([FromBody, Required]MontyHallSimulationDto input)
        {
            var output = _simulationService.Run(input);
            return Ok(output);
        }
    }
}
