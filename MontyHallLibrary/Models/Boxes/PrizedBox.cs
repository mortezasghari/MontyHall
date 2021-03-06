﻿using MontyHallLibrary.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary
{
    public class PrizedBox : MontyHallBox
    {
        private readonly string _prizeName;

        public PrizedBox(string prizeName)
        {
            _prizeName = prizeName ?? throw new ArgumentNullException(nameof(prizeName));
        }

        public override bool Result()
        {
            CheckIsClose();
            return true;
        }

        public override string ToString()
        {

            var output = base.ToString();
            return output is null ? _prizeName : output;
        }
    }
}
