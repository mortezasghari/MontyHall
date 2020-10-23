using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyHallLibrary.Models.GameStates
{
    public class MontyHallGameInitial : IMontyHallGame
    {
        private readonly Dictionary<int, IMontyHallBox> _boxes;
        private readonly Random _rand;

        public MontyHallGameInitial(Dictionary<int, IMontyHallBox> boxes, Random rand, int numberOfHelp)
        {
            if (boxes.Count(b => b.Value is EmptyBox) <= numberOfHelp)
            {
                throw new ArgumentOutOfRangeException("Number of help should be smaller than number of Empty boxes.");
            }

            _boxes = boxes ?? throw new ArgumentNullException(nameof(boxes));
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));
            NumberOfRemainingHelp = numberOfHelp;
        }

        public int NumberOfRemainingHelp { get; private set; }

        public bool FinishGame(IStateManager Context)
        {
            throw new InvalidOperationException("Game hasn't started yet. Select a box to start the game.");
        }

        public string GameResult()
        {
            throw new InvalidOperationException("Game hasn't started yet. Select a box to start the game.");
        }

        public void GetHelp()
        {
            throw new InvalidOperationException("Let select a box before askign for our help.");
        }

        public IList<int> RemainingKeys()
        {
            return _boxes.Keys.ToList();
        }

        public void Select(IStateManager context, int key)
        {
            var game = new MontyHallGameRuning(_boxes, _rand, NumberOfRemainingHelp, key);
            context.ChangeState(game);
        }
    }
}
