using MontyHallLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary
{
    public class EmptyBox : MontyHallBox
    {
        public override bool Result()
        {
            CheckIsClose();
            return false;
        }

        public override string ToString()
        {
            var output = base.ToString();
            return output is null ? "Empty" : output;
        }
    }
}
