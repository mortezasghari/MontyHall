using MontyHallWeb.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MontyHallWeb.Client.Pages
{
    public partial class Index
    {
        private MontyHallSimulationDto simulationDto = new MontyHallSimulationDto();
        private MontyHallSimulationResultDto resultDto;
        private void HandleValidSubmit()
        {
            PostData().Wait();
        }
        protected async Task PostData()
        {
            var result = await Http.PostAsJsonAsync("api/MontyHallSimulation", simulationDto);

            if (result.IsSuccessStatusCode)
            {
                resultDto = await result.Content.ReadFromJsonAsync<MontyHallSimulationResultDto>();
            }
        }
    }
}
