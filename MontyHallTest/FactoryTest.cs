using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace MontyHallTest
{
    public class FactoryTest
    {
        Mock<Random> randomMock = new Mock<Random>();
        Dictionary<int, IBox> _boxes;
        
        public FactoryTest()
        {
            _boxes = new Dictionary<int, IBox>();
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new EmptyBox());
            _boxes.Add(_boxes.Count, new EmptyBox());

            randomMock.Setup<int>(r => r.Next()).Returns(0);

            var factory = new MontyHallFactory(randomMock.Object);
            factory.AddBox(new EmptyBox());
            factory.AddBox(new PrizedBox("Car"));
            factory.AddBox(new EmptyBox());

        }

        [Fact]
        public void Test1()
        {
            var factory = new MontyHallFactory(randomMock.Object);
            factory.AddBox(new EmptyBox());
            factory.AddBox(new EmptyBox());
            factory.AddBox(new EmptyBox());


            Assert.Throws<InvalidOperationException>(() => factory.Build(1));

        }

        [Fact]
        public void Test2()
        {
            var factory = new MontyHallFactory(randomMock.Object);
            factory.AddBox(new EmptyBox());
            factory.AddBox(new PrizedBox("Car"));
            factory.AddBox(new EmptyBox());

            Assert.Throws<ArgumentOutOfRangeException>(() => factory.Build(2));

        }

        [Fact]
        public void Test3()
        {

            var box = new EmptyBox();
            box.IsOpen = true;
            var factory = new MontyHallFactory(randomMock.Object);
            factory.AddBox(box);
            factory.AddBox(new PrizedBox("Car"));
            factory.AddBox(new EmptyBox());

            Assert.Throws<InvalidOperationException>(() => factory.Build(1));

        }

        [Fact]
        public void Test4()
        {
            var factory = new MontyHallFactory(randomMock.Object);
            factory.AddBox(new EmptyBox());
            factory.AddBox(new PrizedBox("Car"));
            factory.AddBox(new EmptyBox());

            var gameContext = factory.Build(1);

            Assert.IsType<MontyHallContexts>(gameContext);

            var keys = gameContext.RemainingKeys();

            Assert.Equal(3, keys.Count);
        }

    }
}
