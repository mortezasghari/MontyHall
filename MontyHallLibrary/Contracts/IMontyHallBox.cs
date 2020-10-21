using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IMontyHallBox
    {
        bool IsOpen { get; }

        void Open();
        bool Result();
        string ResultString();
    }
}
