using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MontyHallService.SettingsModel
{
    public class MontyHallSetting
    {
        public int Boxes { get; set; }
        public int Helps { get; set; }
        public List<string> Prizes { get; set; }

        public bool Validate()
        {
            return ValidatePrizes() && ValidateHelps();
        }

        private bool ValidatePrizes()
        {
            if (Boxes > Prizes.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool ValidateHelps()
        {
            if (Boxes - Prizes.Count > Helps)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
