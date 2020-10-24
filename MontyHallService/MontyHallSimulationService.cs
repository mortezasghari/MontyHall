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

        public MontyHallSimulationResultDto Run(MontyHallSimulationDto input)
        {
            if (_setting.Validate())
            {
                int wins = 0;

                for (int i = 0; i < input.Repetation; i++)
                {
                    var game = Factory();

                    int select = game.RemainingKeys().RandomSelection(_rand);

                    game.Select(select);

                    for (int j = 0; j < _setting.Helps; j++)
                    {
                        game.GetHelp();

                        if (input.ShouldChange)
                        {
                            select = game.RemainingKeys().RandomSelection(_rand);

                            game.Select(select);
                        }
                    }

                    if (game.FinishGame())
                    {
                        wins++;
                    }
                }

                double persentage = (double)wins / input.Repetation;

                return new MontyHallSimulationResultDto
                {
                    Wins = wins,
                    Repetation = input.Repetation,
                    Persentage = persentage.ToString("P", CultureInfo.InvariantCulture),
                    ShouldChange = input.ShouldChange,
                    SimulationTime = DateTime.Now
                };
            }

            else
            {
                throw new InvalidOperationException("Provided Setting is not Valid please check it and run application again.");
            }

        }

        private IMontyHallContext Factory()
        {
            _factory.Clear();
            var prizesDic = RandomizePrizes();
            CreateBoxes(prizesDic);
            return _factory.Build(_setting.Helps);
        }

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
