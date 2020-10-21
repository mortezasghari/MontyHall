using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IMontyHallFactory
    {
        IMontyHallFactory Clear();
        IList<string> Prizes { get; }

        IMontyHallFactory AddPrize(string prize);
        IMontyHallFactory NumberofBox(int number);
        IMontyHallFactory NumerOfHelp(int help);
        IMontyHallFactory AddRandom(Random rand);

        IMontyHallGame Build();
    }
}
