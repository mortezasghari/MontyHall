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
    public class FinishTest
    {
        Mock<IMontyHallContextManager> context = new Mock<IMontyHallContextManager>();
        Mock<IBasicMontyHallStates> state = new Mock<IBasicMontyHallStates>();

        public FinishTest()
        {
            context.Setup(s => s.ChangeState(state.Object));
        }

        [Fact]
        public void Test1()
        {
            var finish = new MontyHallFinished(new EmptyBox());

            Assert.Throws<InvalidOperationException>(() => finish.GetHelp());
            Assert.Throws<InvalidOperationException>(() => finish.Select(context.Object ,1));

        }

        [Fact]
        public void Test2()
        {
            var finish = new MontyHallFinished(new EmptyBox());

            Assert.False(finish.FinishGame(context.Object));
            Assert.Equal("Empty", finish.GameResult());
            Assert.Equal("Empty", finish.ToString());
            Assert.Equal(0, finish.RemainingKeys().Count);

        }

        [Fact]
        public void Test3()
        {
            var finish = new MontyHallFinished(new PrizedBox("Car"));

            Assert.True(finish.FinishGame(context.Object));
            Assert.Equal("Car", finish.GameResult());
            Assert.Equal("Car", finish.ToString());
            Assert.Equal(0, finish.RemainingKeys().Count);
        }
    }
}
