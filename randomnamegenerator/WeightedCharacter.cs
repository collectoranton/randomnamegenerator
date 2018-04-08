using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    class WeightedCharacter
    {
        public char Key { get; }
        public int WeightIndex { get; private set; }

        public WeightedCharacter(char key, int index)
        {
            Key = key;
            WeightIndex = index;
        }

        public void IncrementWeight() => WeightIndex++;
    }
}
