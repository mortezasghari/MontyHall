using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts.Abstracts
{
    public interface IGameProcess
    {
        /// <summary>
        /// Finishes the game and opens the selected box.
        /// </summary>
        /// <param name="Context"></param>
        /// <returns>It will return a true if you win and false if you lose.</returns>
        bool FinishGame(IStateManager Context);

        /// <summary>
        /// Select a box
        /// </summary>
        /// <param name="Id">Id of the box which you have choseen</param>
        void Select(IStateManager context, int key);
    }
}
