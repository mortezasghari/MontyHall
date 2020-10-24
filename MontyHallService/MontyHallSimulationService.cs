using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using MontyHallLibrary.Helper;
using MontyHallService.Contracts;
using MontyHallService.SettingsModel;
using MontyHallWeb.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;

namespace MontyHallService
{
    public class MontyHallSimulationService : IMontyHallSimulationService
    {
        private readonly IMontyHallFactory _factory;
        private readonly MontyHallSetting _setting;
        private readonly Random _rand;

        public MontyHallSimulationService(IMontyHallFactory factory, MontyHallSetting setting, Random rand)
        {
            _factory = factory ?? throw new ArgumentNullException(nameof(factory));
            _setting = setting ?? throw new ArgumentNullException(nameof(setting));
            _rand = rand ?? throw new ArgumentNullException(nameof(rand));
        }

        /// <summary>
        /// Simulation Implentation.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public MontyHallSimulationResultDto Run(MontyHallSimulationDto input)
        {
            ///Validate Setting is Okey
            if (_setting.Validate())
            {
                int wins = 0;

                for (int i = 0; i < input.Repetation; i++)
                {
                    /// Create The game context.
                    var game = Factory();

                    /// Pick a Random Number.
                    int select = game.RemainingKeys().RandomSelection(_rand);

                    /// Select a Box
                    game.Select(select);

                    /// You can ask for as much help as the game allows.
                    for (int j = 0; j < _setting.Helps; j++)
                    {
                        game.GetHelp();

                        /// If Simulation asks for you can change your selection. 
                        if (input.ShouldChange)
                        {
                            select = game.RemainingKeys().RandomSelection(_rand);

                            game.Select(select);
                        }
                    }

                    /// Finish the game and check if You won or lost. 
                    if (game.FinishGame())
                    {
                        wins++;
                    }
                }

                /// Calculate the win persentage
                double percentage = (double)wins / input.Repetation;

                return new MontyHallSimulationResultDto
                {
                    Wins = wins,
                    Repetation = input.Repetation,
                    Percentage = percentage.ToString("P", CultureInfo.InvariantCulture),
                    ShouldChange = input.ShouldChange,
                    SimulationTime = DateTime.Now
                };
            }

            else
            {
                throw new InvalidOperationException("Provided Setting is not Valid please check it and run application again.");
            }

        }

        /// <summary>
        /// Create the Game Context using Monty Hall Factory.
        /// </summary>
        /// <returns></returns>
        private IMontyHallContext Factory()
        {
            _factory.Clear();
            var prizesDic = RandomizePrizes();
            CreateBoxes(prizesDic);
            return _factory.Build(_setting.Helps);
        }

        /// <summary>
        /// Alocates Prizes Randomly
        /// </summary>
        /// <returns></returns>
        private Dictionary<int, string> RandomizePrizes()
        {
            Dictionary<int, string> output = new Dictionary<int, string>();

            foreach ( var item in _setting.Prizes)
            {
                bool isPlaced = false;
                do
                {
                    var index = _rand.Next(_setting.Boxes);

                    if (!output.ContainsKey(index))
                    {
                        output.Add(index, item);
                        isPlaced = true;
                    }

                } while (!isPlaced);
            }
            return output;
        }

        /// <summary>
        /// Create the Boxes.
        /// </summary>
        /// <param name="prizes"></param>
        private void CreateBoxes(Dictionary<int, string> prizes)
        {

            for (int i = 0; i < _setting.Boxes; i++)
            {
                if (prizes.TryGetValue(i, out string prize))
                {
                    _factory.AddBox(new PrizedBox(prize));
                }
                else
                {
                    _factory.AddBox(new EmptyBox());
                }
            }

        }
    }
}
