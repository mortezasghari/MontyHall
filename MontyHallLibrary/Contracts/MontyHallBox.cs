using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MontyHallLibrary.Contracts
{
    public abstract class MontyHallBox : IMontyHallBox
    {
        

        public bool IsOpen { get; private set; } = false;

        
        public void Open()
        {
            IsOpen = true;
        }

        public abstract bool Result();
        public abstract string ResultString();


        public override string ToString()
        {
            if (IsOpen)
            {
                return ResultString();
            }
            else
            {
                return "UnKnown";
            }
        }
    }
}
