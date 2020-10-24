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
    public class InitialTest
    {
        Mock<IMontyHallContextManager> context = new Mock<IMontyHallContextManager>();
        Mock<IBasicMontyHallStates> state = new Mock<IBasicMontyHallStates>();
        Mock<Random> randomMock = new Mock<Random>();
        Dictionary<int, IBox> _boxes;
        MontyHallInitial initial;


        public InitialTest()
        {
            _boxes = new Dictionary<int, IBox>();
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new PrizedBox("Car"));
            _boxes.Add(_boxes.Count, new EmptyBox());

            randomMock.Setup(r => r.Next()).Returns(0);
            context.Setup(s => s.ChangeState(state.Object));

            initial = new MontyHallInitial(_boxes, randomMock.Object, 1);
        }

        [Fact]
        public void Test1()
        {
            Assert.Throws<InvalidOperationException>(() => initial.FinishGame(context.Object));
            Assert.Throws<InvalidOperationException>(() => initial.GameResult());
            Assert.Throws<InvalidOperationException>(() => initial.GetHelp());
        }

        [Fact]
        public void Test2()
        {
            var keys = initial.RemainingKeys();

            Assert.Equal(3, keys.Count);
            Assert.Equal(0, keys[0]);
            Assert.Equal(1, keys[1]);
            Assert.Equal(2, keys[2]);
        }
    }
}
