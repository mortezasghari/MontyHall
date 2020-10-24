using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IMontyHallFactory
    {
        IMontyHallFactory Clear();

        IMontyHallFactory AddBox(IBox box);

        IMontyHallContext Build(int NumberofHelp);

    }
}
