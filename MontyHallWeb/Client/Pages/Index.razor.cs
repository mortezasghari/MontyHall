using Microsoft.Extensions.Configuration;
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
        private List<MontyHallSimulationResultDto> resultDto = new List<MontyHallSimulationResultDto>();


        private void HandleValidSubmit()
        {
            PostData();
        }
        protected async Task PostData()
        {
            var result = await Http.PostAsJsonAsync("api/MontyHallSimulation", simulationDto);

            if (result.IsSuccessStatusCode)
            {
                try
                {
                    resultDto.Add(await result.Content.ReadFromJsonAsync<MontyHallSimulationResultDto>());
                    StateHasChanged();
                }
                catch (Exception e)
                {
                    await ShowMessage(e.Message);
                }
            }
            else
            {
                await ShowMessage(result.ReasonPhrase);
            }
        }

        private async Task ShowMessage(string message)
        {
            
            await JsRuntime.InvokeAsync<bool>("alert", new object[] { message });
        }
    }
}
