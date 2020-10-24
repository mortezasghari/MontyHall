using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyHallLibrary.Abstracts
{
    public abstract class MontyHallAbstractGame : IBasicMontyHallStates
    {
        protected readonly Dictionary<int, IBox> _boxes;
        protected readonly Random _rand;

        protected MontyHallAbstractGame(Dictionary<int, IBox> boxes, Random rand, int numberOfHelp)
        {
            if (!boxes.Any(b => b.Value is PrizedBox))
            {
                throw new InvalidOperationException("Atleast one box should contain Prize.");
            }
            else if (boxes.Count(b => b.Value is EmptyBox) <= numberOfHelp)
            {
                throw new ArgumentOutOfRangeException("Number of help should be smaller than number of Empty boxes.");
            }
            else if(boxes.Any(b => b.Value.IsOpen))
            {
                throw new InvalidOperationException("All Boxes should be closed.");
            }
            else
            {
                _boxes = boxes ?? throw new ArgumentNullException(nameof(boxes));
                _rand = rand ?? throw new ArgumentNullException(nameof(rand));
                NumberOfRemainingHelp = numberOfHelp;
            }
        }

        public int NumberOfRemainingHelp { get; protected set; }

        public abstract bool FinishGame(Contracts.Abstracts.IMontyHallContextManager Context);
        public abstract string GameResult();
        public abstract void GetHelp();
        public abstract IList<int> RemainingKeys();
        public abstract void Select(Contracts.Abstracts.IMontyHallContextManager context, int key);


        public override string ToString()
        {
            string output = "";

            foreach (var item in _boxes)
            {
                output = $"{output} {item.Key}: {item.Value};";
            }
            
            return output;
        }
    }
}
