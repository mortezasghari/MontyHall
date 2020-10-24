using MontyHallLibrary.Contracts;
using System;
using System.Collections.Generic;

namespace MontyHallLibrary
{
    public class MontyHallContexts : IMontyHallContext
    {
        private IBasicMontyHallStates _state;

        public MontyHallContexts(IBasicMontyHallStates state)
        {
            this._state = state ?? throw new ArgumentNullException(nameof(state));
        }

        public int NumberOfRemainingHelp => _state.NumberOfRemainingHelp;

        public void ChangeState(IBasicMontyHallStates state)
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