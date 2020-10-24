using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace MontyHallService.SettingsModel
{
    public class MontyHallSetting
    {
        /// <summary>
        /// Number of Boxes
        /// The minimum number is 3
        /// </summary>
        public int Boxes { get; set; }

        /// <summary>
        /// Number of Helps 
        /// The Minimum number is 1
        /// </summary>
        public int Helps { get; set; }

        /// <summary>
        /// The list of diffrent prizes.
        /// At least One prizes should be available. 
        /// </summary>
        public List<string> Prizes { get; set; }


        /// <summary>
        /// this Function validate if we can create a game with the provided setting
        /// </summary>
        /// <returns>
        /// True: Ervery things is in order.
        /// False: Something is not right.
        /// </returns>
        public bool Validate()
        {
            return CheckMinimum() &&  ValidateHelps() && Prizes.Any();
        }


        /// <summary>
        /// # of Boxes shuld be higher than # of helps + # prizes other wise the game cannt function
        /// </summary>
        /// <returns>
        /// True: Ervery things is in order.
        /// False: Something is not right.
        /// </returns>
        private bool ValidateHelps()
        {
            return (Boxes > Helps + Prizes.Count);
        }

        /// <summary>
        /// Minimum number of boxes should be 3.
        /// Minimum number of helps should be 1
        /// </summary>
        /// <returns>
        /// True: Ervery things is in order.
        /// False: Something is not right.
        /// </returns>
        private bool CheckMinimum()
        {
            return Helps > 0 && Boxes > 2;
        }
    }
}
