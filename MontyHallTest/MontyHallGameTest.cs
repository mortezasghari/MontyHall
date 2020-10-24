using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace MontyHallTest
{
    public class MontyHallGameTest
    {
        Dictionary<int, IBox> _boxes;
        public MontyHallGameTest()
        {
            _boxes = new Dictionary<int, IBox>();
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new PrizedBox("Car"));
            _boxes.Add(_boxes.Count, new EmptyBox());
        }

        [Fact]
        public void Test1()
        {
            //IMontyHallGame game = new MontyHallGame(_boxes, new Random(), 1);

            //game.Select(1);


            //Assert.True(game.FinishGame());
            //Assert.Equal("Car", game.GameResult());

        }

        [Fact]
        public void Test2()
        {
            //IMontyHallGame game = new MontyHallGame(_boxes, new Random(), 1);

            //var choises = game.RemainingKeys();
            //Assert.Equal(3, choises.Count);

            //game.Select(1);
            //choises = game.RemainingKeys();
            //Assert.Equal(2, choises.Count);

            //game.GetHelp();
            //choises = game.RemainingKeys();
            //Assert.Equal(1, choises.Count);

        }

        [Fact]
        public void FactoryTest()
        {
            //IMontyHallFactory factory = new MontyHallFactory();
            //var game = factory.Clear()
            //    .AddRandom(new Random())
            //    .AddPrize("Car")
            //    .Build();
        }
    }
}
