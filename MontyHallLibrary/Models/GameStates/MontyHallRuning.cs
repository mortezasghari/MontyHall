using MontyHallLibrary.Abstracts;
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
    public class MontyHallRuning : MontyHallAbstractGame
    {
        KeyValuePair<int, IBox> _selected;

        public MontyHallRuning(Dictionary<int, IBox> boxes, Random rand, int numberOfHelp, int selectedKey)
            : base(boxes, rand, numberOfHelp)
        {
            this.Select(selectedKey);
        }

        public override bool FinishGame(Contracts.Abstracts.IMontyHallContextManager Context)
        {

            var newContext = new MontyHallFinished(_selected.Value);
            Context.ChangeState(newContext);
            return newContext.FinishGame(Context);

        }

        public override string GameResult()
        {
            throw new InvalidOperationException("Game is not finished yet.");
        }

        public override void GetHelp()
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

            GetBoxByKey(rand).IsOpen = true;
        }

        public override IList<int> RemainingKeys()
        {
            return _boxes.Where(b => b.Value.IsOpen == false && b.Key != _selected.Key)
                .Select(b => b.Key)
                .ToList();
        }

        public override void Select(Contracts.Abstracts.IMontyHallContextManager context, int key)
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
                _selected = new KeyValuePair<int, IBox>(key, box);
            }
        }

        private IBox GetBoxByKey(int key)
        {
            if (_boxes.TryGetValue(key, out IBox box))
            {
                return box; 
            }
            else
            {
                throw new InvalidOperationException("Provided Key is not valid.");
            }
        }

        public override string ToString()
        {
            return $"Selected box: {_selected.Key}; {base.ToString()}";
        }
    }
}
