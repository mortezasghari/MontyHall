using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using MontyHallLibrary.Models.GameStates;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MontyHallTest
{
    public class ContextTest
    {
        Mock<Random> randomMock = new Mock<Random>();
        Dictionary<int, IBox> _boxes;

        public ContextTest()
        {
            _boxes = new Dictionary<int, IBox>();
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new PrizedBox("Car"));
            _boxes.Add(_boxes.Count, new EmptyBox());

            randomMock.Setup<int>(r => r.Next()).Returns(0);
        }

        [Fact]
        public void Test1()
        {
            var state = new MontyHallInitial(_boxes, randomMock.Object, 1);
            IMontyHallContext context = new MontyHallContexts(state);

            Assert.Throws<InvalidOperationException>(() => context.FinishGame());
            Assert.Throws<InvalidOperationException>(() => context.GameResult());
            Assert.Throws<InvalidOperationException>(() => context.GetHelp());

            var keys = context.RemainingKeys();

            Assert.Equal(3, keys.Count);
            Assert.Equal(0, keys[0]);
            Assert.Equal(1, keys[1]);
            Assert.Equal(2, keys[2]);
        }

        [Fact]
        public void Test2()
        {
            var state = new MontyHallInitial(_boxes, randomMock.Object, 1);
            IMontyHallContext context = new MontyHallContexts(state);

            context.Select(0);

            var remaing = context.RemainingKeys();

            Assert.Equal(2, remaing.Count);
            Assert.Equal(1, remaing[0]);
            Assert.Equal(2, remaing[1]);

            context.GetHelp();
            remaing = context.RemainingKeys();

            Assert.Equal(1, remaing.Count);
            Assert.Equal(1, remaing[0]);


            Assert.Throws<InvalidOperationException>(() => context.GetHelp());
            Assert.Throws<InvalidOperationException>(() => context.Select(2));
            Assert.Throws<InvalidOperationException>(() => context.GameResult());

            var result = context.FinishGame();

            Assert.False(result);
        }

        [Fact]
        public void Test3()
        {
            var state = new MontyHallInitial(_boxes, randomMock.Object, 1);
            IMontyHallContext context = new MontyHallContexts(state);

            context.Select(0);

            Assert.False(context.FinishGame());
            Assert.Equal("Empty", context.GameResult());
            Assert.Equal("Empty", context.ToString());
            Assert.Equal(0, context.RemainingKeys().Count);

            Assert.Throws<InvalidOperationException>(() => context.GetHelp());
            Assert.Throws<InvalidOperationException>(() => context.Select( 1));
        }

        [Fact]
        public void Test4()
        {

            var state = new MontyHallInitial(_boxes, randomMock.Object, 1);
            IMontyHallContext context = new MontyHallContexts(state);

            context.Select(1);

            Assert.True(context.FinishGame());
            Assert.Equal("Car", context.GameResult());
            Assert.Equal("Car", context.ToString());
            Assert.Equal(0, context.RemainingKeys().Count);

            Assert.Throws<InvalidOperationException>(() => context.GetHelp());
            Assert.Throws<InvalidOperationException>(() => context.Select(1));
        }
    }
}
