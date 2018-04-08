using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    class WeightedCharacterLayer
    {
        public WeightedCharacter[] _layer;
        public int Count { get => _layer.Length; }
        public int MaxWeight { get => _layer[_layer.Length - 1].WeightIndex + 1; }

        public WeightedCharacterLayer(string characterSet)
        {
            _layer = new WeightedCharacter[characterSet.Length];

            for (int i = 0; i < characterSet.Length; i++)
                _layer[i] = new WeightedCharacter(characterSet[i], i);
        }

        public void Update(char character)
        {
            var afterWeightedCharacterIndex = false;

            foreach (var weightedCharacter in _layer)
            {
                if (weightedCharacter.Key == character)
                    afterWeightedCharacterIndex = true;

                if (afterWeightedCharacterIndex)
                    weightedCharacter.IncrementWeight();
            }

            if (!afterWeightedCharacterIndex)
                throw new ArgumentException("No such character in layer", nameof(character));
        }

        public char GetCharacter(int index)
        {
            foreach (var weightedCharacter in _layer)
            {
                if (index <= weightedCharacter.WeightIndex)
                    return weightedCharacter.Key;
            }

            throw new Exception("Could not get character from index");
        }
    }
}
