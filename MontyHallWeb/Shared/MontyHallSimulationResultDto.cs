using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallWeb.Shared
{
    public class MontyHallSimulationResultDto 
    {
        public DateTime SimulationTime { get; set; }
        public string Persentage { get; set; }
        public int Wins { get; set; }
        public int Repetation { get; set; }
        public bool ShouldChange { get; set; }
    }
}
