using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace MontyHallLibrary.Models.GameStates
{
    public class MontyHallFinished : IBasicMontyHallStates
    {
        private readonly IBox _selectedBox;

        public MontyHallFinished(IBox selectedBox)
        {
            _selectedBox = selectedBox;
        }

        public int NumberOfRemainingHelp => 0;

        public bool FinishGame(Contracts.Abstracts.IMontyHallContextManager Context)
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

        public void Select(Contracts.Abstracts.IMontyHallContextManager context, int key)
        {
            throw new InvalidOperationException("Game has finished.");
        }

        public override string ToString()
        {
            return GameResult();
        }
    }
}
