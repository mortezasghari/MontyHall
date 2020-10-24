using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IMontyHallContext: IMontyHall, IMontyHallContextManager
    {
    }
}
