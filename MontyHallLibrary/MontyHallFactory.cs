using MontyHallLibrary.Helper;
using MontyHallLibrary.Models.GameStates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading;

namespace MontyHallLibrary.Contracts
{
    public class MontyHallFactory : IMontyHallFactory
    {
        private Dictionary<int, IBox> _boxes;
        private Random _rand;

        public MontyHallFactory(Random rand)
        {
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));
            _boxes = new Dictionary<int, IBox>();
        }

        public IMontyHallFactory AddBox(IBox box)
        {
            _boxes.Add(_boxes.Count, box);
            return this;
        }

        public IMontyHallContext Build(int numberofHelp)
        {
            var game = new MontyHallInitial(_boxes, _rand, numberofHelp);
            return new MontyHallContexts(game);
        }

        public IMontyHallFactory Clear()
        {
            _boxes = new Dictionary<int, IBox>();
            return this;
        }
    }
}
