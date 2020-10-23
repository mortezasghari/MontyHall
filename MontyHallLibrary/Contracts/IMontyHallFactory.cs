using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IMontyHallFactory
    {
        IMontyHallFactory Clear();

        IMontyHallFactory AddBox(IMontyHallBox box);

        IMontyHallGameContext Build(int NumberofHelp);

    }
}
