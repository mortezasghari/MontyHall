using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts.Abstracts
{
    public interface IStateManager
    {
        void ChangeState(IMontyHallGame state);
    }
}
