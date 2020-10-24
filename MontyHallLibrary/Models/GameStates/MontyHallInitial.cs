using MontyHallLibrary.Abstracts;
using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MontyHallLibrary.Models.GameStates
{
    public class MontyHallInitial : MontyHallAbstractGame
    {

        public MontyHallInitial(Dictionary<int, IBox> boxes, Random rand, int numberOfHelp) 
            : base(boxes, rand, numberOfHelp)
        {

        }

        public override bool FinishGame(Contracts.Abstracts.IMontyHallContextManager Context)
        {
            throw new InvalidOperationException("Game hasn't started yet. Select a box to start the game.");
        }

        public override string GameResult()
        {
            throw new InvalidOperationException("Game hasn't started yet. Select a box to start the game.");
        }

        public override void GetHelp()
        {
            throw new InvalidOperationException("Let select a box before askign for our help.");
        }

        public override IList<int> RemainingKeys()
        {
            return _boxes.Keys.ToList();
        }

        public override void Select(Contracts.Abstracts.IMontyHallContextManager context, int key)
        {
            var game = new MontyHallRuning(_boxes, _rand, NumberOfRemainingHelp, key);
            context.ChangeState(game);
        }
    }
}
