using MontyHallLibrary.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace MontyHallLibrary.Contracts
{
    public abstract class MontyHallBox : IBox
    {
        protected bool _isOpen = false;

        public bool IsOpen
        {
            get => _isOpen;
            set
            {
                /// A Box Which has been open cant be closed. 
                if (value)
                {
                    _isOpen = value;
                }
            }
        }

        public abstract bool Result();

        protected void CheckIsClose()
        {
            if (!IsOpen)
            {
                throw new InvalidOperationException("The box is close.");
            }
        }


        public override string ToString()
        {
            if (IsOpen)
            {
                return null;
            }
            else
            {
                return "Closed";
            }
        }
    }
}
