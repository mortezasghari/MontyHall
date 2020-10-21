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
            return false;
        }

        public override string ResultString()
        {
            return "Empty";
        }
    }
}
