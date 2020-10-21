using System;
using System.Collections.Generic;
using System.Text;

namespace MontyHallLibrary.Helper
{
    public static class CollectionExtentions
    {
        public static T RandomSelection<T>(this IList<T> input, Random rand)
        {
            if (input is null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (rand is null)
            {
                throw new ArgumentNullException(nameof(rand));
            }

            if (input.Count == 0)
            {
                throw new ArgumentOutOfRangeException("List should have more member in it.");
            }

            return input[rand.Next(input.Count)];
        }
    }
}
