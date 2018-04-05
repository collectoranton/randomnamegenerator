using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    class WeightedCharacterStack
    {
        WeightedCharacterLayer[] layers;
        Random random = new Random();

        public int Depth { get => layers.Length; }
        public string CharacterSet { get; private set; }

        public WeightedCharacterStack(int depth, string characterSet)
        {
            CharacterSet = characterSet;
            layers = new WeightedCharacterLayer[depth];

            for (int i = 0; i < depth; i++)
                layers[i] = new WeightedCharacterLayer(characterSet);
        }

        public void Update(string updateString)
        {
            if (updateString.Length > Depth)
                throw new ArgumentException("Update string can not be longer than stack depth", "updateString");

            UpdateToStackDepth(updateString);
        }

        public void UpdateToStackDepth(string updateString)
        {
            if (updateString.Length > Depth)
                updateString = updateString.Substring(0, Depth);

            for (int i = 0; i < updateString.Length; i++)
                layers[i].Update(updateString[i]);
        }

        public List<WeightedCharacterLayer> GetLayers() => layers.ToList();

        public string GetRandomString(int length)
        {
            if (length > Depth)
                throw new ArgumentException("Length can not be longer than stack depth", "length");

            var randomString = "";

            for (int i = 0; i < length; i++)
                randomString += layers[i].GetCharacter(random.Next(0, layers[i].MaxWeight));

            return randomString;
        }
    }
}
