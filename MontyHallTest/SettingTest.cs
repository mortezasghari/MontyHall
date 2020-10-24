using MontyHallService.SettingsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace MontyHallTest
{
    public class SettingTest
    {

        [Theory]
        [InlineData(3, 1, false)]
        [InlineData(3, 1, true, "Car")]
        [InlineData(3, -1, false, "Car")]
        [InlineData(3, 2, false, "Car")]
        [InlineData(3, 4, false, "Car")]
        [InlineData(6, 3, false, "Car", "Bike", "Bicycle")]
        public void TestSetting(int boxes, int help, bool result, params string[] prizes)        
        {
            MontyHallSetting monty = new MontyHallSetting { Boxes = boxes, Helps = help, Prizes = prizes.ToList() };

            var validate = monty.Validate();

            Assert.Equal(result, validate);
        }

    }
}
