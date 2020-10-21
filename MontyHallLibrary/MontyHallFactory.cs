using MontyHallLibrary.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace MontyHallLibrary.Contracts
{
    public class MontyHallFactory : IMontyHallFactory
    {
        private Dictionary<int, IMontyHallBox> _boxes;
        private List<string> _prizes;
        private Random _rand;
        private int _help;

        public IList<string> Prizes => _prizes;

        public IMontyHallFactory AddPrize(string prize)
        {
            if (prize is null)
            {
                throw new ArgumentNullException(nameof(prize));
            }

            var rand = _boxes.Where(b => b.Value is null).Select(b => b.Key).ToList().RandomSelection(_rand);
            _boxes[rand] = new PrizedBox(prize);

            return this;
        }

        public IMontyHallFactory AddRandom(Random rand)
        {
            _rand = rand;
            return this;
        }

        public IMontyHallGame Build()
        {
            
            for (int i = 0; i < _boxes.Count; i++)
            {
                if (_boxes[i] is null)
                {
                    _boxes[i] = new EmptyBox();
                }
            }

            return new MontyHallGame(_boxes, _rand, _help);

        }

        public IMontyHallFactory Clear()
        {
            _boxes = new Dictionary<int, IMontyHallBox>();

            NumberofBox(3);
            NumerOfHelp(1);

            return this;
        }

        public IMontyHallFactory NumberofBox(int number)
        {
            if (number < _boxes.Count)
            {
                throw new ArgumentOutOfRangeException("You cam only add new Boxes you can remove from it.");
            }

            for (int i = _boxes.Count; i < number; i++)
            {
                _boxes.Add(_boxes.Count, null);
            }

            return this;
        }

        public IMontyHallFactory NumerOfHelp(int help)
        {
            this._help = help;
            return this;
        }
    }
}
