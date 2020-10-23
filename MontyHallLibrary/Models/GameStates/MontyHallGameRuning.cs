using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using MontyHallLibrary.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Xml;

namespace MontyHallLibrary.Models.GameStates
{
    public class MontyHallGameRuning : IMontyHallGame
    {
        private readonly Dictionary<int, IMontyHallBox> _boxes;
        private readonly Random _rand;

        KeyValuePair<int, IMontyHallBox> _selected;
        

        public MontyHallGameRuning(Dictionary<int, IMontyHallBox> boxes, Random rand, int numberOfHelp, int selectedKey)
        {
            if (boxes.Count(b => b.Value is EmptyBox) <= numberOfHelp)
            {
                throw new ArgumentOutOfRangeException("Number of help should be smaller than number of Empty boxes.");
            }

            _boxes = boxes ?? throw new ArgumentNullException(nameof(boxes));
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));
            NumberOfRemainingHelp = numberOfHelp;
            this.Select(selectedKey);

        }

        public int NumberOfRemainingHelp { get; private set; }

        public bool FinishGame(IStateManager Context)
        {

            var newContext = new MontyHallGameFinished(_selected.Value);
            Context.ChangeState(newContext);
            return newContext.FinishGame(Context);

        }

        public string GameResult()
        {
            throw new InvalidOperationException("Game is not finished yet.");
        }

        public void GetHelp()
        {
            if (NumberOfRemainingHelp < 1)
            {
                throw new InvalidOperationException("You can ask for any more Help");
            }

            NumberOfRemainingHelp--;

            var rand = _boxes.Where(b => b.Value is EmptyBox && b.Value.IsOpen == false && b.Key != _selected.Key)
                .Select(b => b.Key)
                .ToList()
                .RandomSelection(_rand);
        }

        public IList<int> RemainingKeys()
        {
            return _boxes.Where(b => b.Value.IsOpen == false && b.Key != _selected.Key)
                .Select(b => b.Key)
                .ToList();
        }

        public void Select(IStateManager context, int key)
        {
            Select(key);
        }

        private void Select(int key)
        {
            var box = GetBoxByKey(key);

            if (box.IsOpen)
            {
                throw new InvalidOperationException("You cant select an Open Box");
            }
            else
            {
                _selected = new KeyValuePair<int, IMontyHallBox>(key, box);
            }
        }

        private IMontyHallBox GetBoxByKey(int key)
        {
            if (_boxes.TryGetValue(key, out IMontyHallBox box))
            {
                return box; 
            }
            else
            {
                throw new InvalidOperationException("Provided Key is not valid.");
            }
        }
    }
}
