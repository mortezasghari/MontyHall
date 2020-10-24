using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Contracts
{
    public interface IBox
    {
        bool Result();

        bool IsOpen { get; set; }
    }
}
