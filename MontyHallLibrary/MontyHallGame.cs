using MontyHallLibrary.Contracts;
using MontyHallLibrary.Helper;
using MontyHallLibrary.Models.Enums;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace MontyHallLibrary
{
    public class MontyHallGame : IMontyHallGame
    {

        private readonly Dictionary<int, IMontyHallBox> _boxes;
        private readonly Random _rand;


        private KeyValuePair<int, IMontyHallBox> _selected;
        private GameStateEnum gameState;
        
        public MontyHallGame(Dictionary<int, IMontyHallBox> boxes, Random rand, int numberOfHelp)
        {
            if (boxes.Count(b => b.Value is EmptyBox) <= numberOfHelp)
            {
                throw new ArgumentOutOfRangeException("Number of help should be smaller than number of Empty boxes.");
            }

            _boxes = boxes ?? throw new ArgumentNullException(nameof(boxes));
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));

            NumberOfRemainingHelp = numberOfHelp;
            gameState = GameStateEnum.PreStart;
        }

        public int NumberOfRemainingHelp { get; private set; }

        public bool FinishGame()
        {
            if (gameState != GameStateEnum.OnGoing)
            {
                throw new InvalidOperationException("You cant finish a game you havent started yet.");
            }

            _selected.Value.Open();
            gameState = GameStateEnum.Finish;
            return _selected.Value.Result();
        }

        public string GameResult()
        {
            if (gameState == GameStateEnum.Finish)
            {
                return _selected.Value.ResultString();
            }
            else
            {
                throw new InvalidOperationException("Game is not finished yet.");
            }
        }

        public void GetHelp()
        {
            if (gameState != GameStateEnum.OnGoing)
            {
                throw new InvalidOperationException("Please select a Box before asking for help");
            }
            else if (NumberOfRemainingHelp < 1)
            {
                throw new InvalidOperationException("You can ask for any more Help");
            }

            NumberOfRemainingHelp--;

            var rand = _boxes.Where(b => b.Value is EmptyBox && b.Value.IsOpen == false && b.Key != _selected.Key)
                .Select(b => b.Key)
                .ToList()
                .RandomSelection(_rand);

            GetBoxById(rand).Open();
        }

        public IList<int> RemainingKeys()
        {
            return gameState switch
            {
                GameStateEnum.PreStart => _boxes.Keys.ToList(),
                GameStateEnum.OnGoing => _boxes.Where(b => b.Value.IsOpen == false && b.Key != _selected.Key)
                    .Select(b => b.Key)
                    .ToList(),
                GameStateEnum.Finish => null,
                _ => throw new ArgumentOutOfRangeException("Game state is not valid"),
            };
        }

        public void Select(int key)
        {
            if (gameState == GameStateEnum.Finish)
            {
                throw new InvalidOperationException("The game is already finished.");
            }

            var box = GetBoxById(key);
            
            if (box.IsOpen)
            {
                throw new InvalidOperationException("You cant Select an Open Box.");
            }
            gameState = GameStateEnum.OnGoing;
            _selected = new KeyValuePair<int, IMontyHallBox>(key, box);
        }


        public override string ToString()
        {
            string output = "";

            if (gameState != GameStateEnum.PreStart)
            {
                output = $"You have selected box Number: {_selected.Key}";

            }

            foreach (var item in _boxes)
            {
                output = $"{output}; {item.Key}: {item.Value}";
            }
            
            return output;
        }

        private IMontyHallBox GetBoxById(int key)
        {
            if (_boxes.TryGetValue(key, out IMontyHallBox ouput))
            {
                return ouput;
            }
            else
            {
                throw new InvalidOperationException("Provided Key is not Valid.");
            }
        }
    }
}