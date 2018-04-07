using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    class WeightedCharacterLayer
    {
        public WeightedCharacter[] Weights { get; private set; }
        public int Count { get => Weights.Length; }
        public int MaxWeight { get => Weights[Weights.Length - 1].WeightIndex + 1; }

        public WeightedCharacterLayer(string characterSet)
        {
            Weights = new WeightedCharacter[characterSet.Length];

            for (int i = 0; i < characterSet.Length; i++)
                Weights[i] = new WeightedCharacter(characterSet[i], i);
        }

        public void Update(char character)
        {
            var afterWeightedCharacterIndex = false;

            foreach (var weightedCharacter in Weights)
            {
                if (weightedCharacter.Key == character)
                    afterWeightedCharacterIndex = true;

                if (afterWeightedCharacterIndex)
                    weightedCharacter.Increment();
            }

            if (!afterWeightedCharacterIndex)
                throw new ArgumentException("No such character in layer", nameof(character));
        }

        public char GetCharacter(int index)
        {
            foreach (var weightedCharacter in Weights)
            {
                if (index <= weightedCharacter.WeightIndex)
                    return weightedCharacter.Key;
            }

            throw new Exception("Could not get character from index");
        }
    }
}
