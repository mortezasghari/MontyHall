using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using MontyHallLibrary.Contracts.Abstracts;
using MontyHallLibrary.Models.GameStates;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MontyHallTest.StateTest
{
    public class RuningTest
    {
        Mock<IMontyHallContextManager> context = new Mock<IMontyHallContextManager>();
        Mock<IBasicMontyHallStates> state = new Mock<IBasicMontyHallStates>();
        Mock<Random> randomMock = new Mock<Random>();
        Dictionary<int, IBox> _boxes;

        public RuningTest()
        {
            _boxes = new Dictionary<int, IBox>();
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new PrizedBox("Car"));
            _boxes.Add(_boxes.Count, new EmptyBox());

            randomMock.Setup<int>(r => r.Next()).Returns(0);
            context.Setup(s => s.ChangeState(state.Object));
        }

        [Fact]
        public void Test1()
        {
            Assert.Throws<InvalidOperationException>(() => new MontyHallRuning(_boxes, randomMock.Object, 1, 3));
        }



        [Fact]
        public void Test2()
        {
            var running = new MontyHallRuning(_boxes, randomMock.Object, 1, 0);

            var remaing = running.RemainingKeys();

            Assert.Equal(2, remaing.Count);
            Assert.Equal(1, remaing[0]);
            Assert.Equal(2, remaing[1]);

            running.GetHelp();
            remaing = running.RemainingKeys();

            Assert.Equal(1, remaing.Count);
            Assert.Equal(1, remaing[0]);


            Assert.Throws<InvalidOperationException>(() => running.GetHelp());
            Assert.Throws<InvalidOperationException>(() => running.Select(context.Object, 2));
        }

        [Fact]
        public void Test3()
        {
            var running = new MontyHallRuning(_boxes, randomMock.Object, 1, 0);

            Assert.Throws<InvalidOperationException>(() => running.GameResult());
        }

        [Fact]
        public void Test4()
        {
            var running = new MontyHallRuning(_boxes, randomMock.Object, 1, 0);

            var result = running.FinishGame(context.Object);

            Assert.False(result);
        }

    }
}
