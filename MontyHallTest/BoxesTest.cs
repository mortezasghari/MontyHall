using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using MontyHallLibrary;
using MontyHallLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace MontyHallTest
{
    public class BoxesTest
    {
        [Fact]
        public void EmptyBoxTest()
        {
            var box = new EmptyBox();
            var tostring = "Empty";
            var win = false;

            Assert.False(box.IsOpen);

            Assert.Throws<InvalidOperationException>(() =>box.Result());
            Assert.Equal("Closed", box.ToString());

            box.IsOpen = true;

            Assert.True(box.IsOpen);
            Assert.Equal(tostring,box.ToString());
            Assert.Equal(win, box.Result());


            box.IsOpen = false;
            Assert.True(box.IsOpen);

        }

        [Fact]
        public void PrizedBoxTest()
        {

            var box = new PrizedBox("Car");
            var tostring = "Car";
            var win = true;


            Assert.False(box.IsOpen);

            Assert.Throws<InvalidOperationException>(() => box.Result());
            Assert.Equal("Closed", box.ToString());

            box.IsOpen = true;

            Assert.True(box.IsOpen);
            Assert.Equal(tostring, box.ToString());
            Assert.Equal(win, box.Result());


            box.IsOpen = false;
            Assert.True(box.IsOpen);

        }
    }
}
