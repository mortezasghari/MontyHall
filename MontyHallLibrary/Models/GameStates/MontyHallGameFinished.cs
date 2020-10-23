using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MontyHallLibrary.Models.GameStates
{
    public class MontyHallGameFinished : IMontyHallGame
    {
        private readonly IMontyHallBox _selectedBox;

        public MontyHallGameFinished(IMontyHallBox selectedBox)
        {
            _selectedBox = selectedBox;
        }

        public int NumberOfRemainingHelp => 0;

        public bool FinishGame(IStateManager Context)
        {
            _selectedBox.IsOpen = true;
            return _selectedBox.Result();
        }

        public string GameResult()
        {
            return _selectedBox.ToString();
        }

        public void GetHelp()
        {
            throw new InvalidOperationException("Game has finished.");
        }

        public IList<int> RemainingKeys()
        {
            return new int[] { };
        }

        public void Select(IStateManager context, int key)
        {
            throw new InvalidOperationException("Game has finished.");
        }
    }
}
