using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts.Abstracts
{
    public interface IMontyHallContextManager
    {
        bool FinishGame();
        void Select(int key);
        void ChangeState(IBasicMontyHallStates state);
    }
}
