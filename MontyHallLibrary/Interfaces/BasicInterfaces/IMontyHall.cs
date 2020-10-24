using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts.Abstracts
{
    public interface IMontyHall
    {
        /// <summary>
        /// This will return a list of Id which you can chose of.
        /// </summary>
        IList<int> RemainingKeys();

        /// <summary>
        /// This will return the number of remaining Help that you can ask. 
        /// Each time you ask for help an empty box will be opened. 
        /// </summary>
        int NumberOfRemainingHelp { get; }

        /// <summary>
        /// Asking for a help
        /// </summary>
        void GetHelp();

        /// <summary>
        /// Finishes the game and opens the selected box.
        /// </summary>
        /// <returns>It will return a message which indicates you won or lost.</returns>
        string GameResult();
    }
}
