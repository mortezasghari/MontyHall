using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using MontyHallLibrary.Helper;
using MontyHallLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MontyHallLibrary
{
    public class MontyHallGame : IMontyHallGameContext
    {
        private IMontyHallGame _state;

        public MontyHallGame(IMontyHallGame state)
        {
            this._state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public int NumberOfRemainingHelp => _state.NumberOfRemainingHelp;

        public void ChangeState(IMontyHallGame state)
        {
            _state = state;
        }

        public bool FinishGame()
        {
            return _state.FinishGame(this);
        }

        public string GameResult()
        {
            return _state.GameResult();
        }

        public void GetHelp()
        {
            _state.GetHelp();
        }

        public IList<int> RemainingKeys()
        {
            return _state.RemainingKeys();
        }

        public void Select(int key)
        {
            _state.Select(this, key);
        }
    }
}