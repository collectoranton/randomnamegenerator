using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    class WeightedCharacterStack : IUpdatableWithString
    {
        List<WeightedCharacterLayer> _layers;
        Dictionary<int, int> _wordLengths;
        Random _random;

        public int Depth { get => _layers.Count; }
        public string CharacterSet { get; }

        public WeightedCharacterStack(string characterSet)
        {
            CharacterSet = characterSet;
            _layers = new List<WeightedCharacterLayer>();
            _wordLengths = new Dictionary<int, int>();
            _random = new Random();
        }

        public WeightedCharacterStack(string characterSet, int setStackDepth)
            : this(characterSet)
        {
            AddLevelsToStack(setStackDepth);
        }

        public void Update(string updateString)
        {
            if (updateString.Length > Depth)
                AddLevelsToStack(updateString.Length - Depth);

            UpdateToStackDepth(updateString);
        }

        public void AddLevelsToStack(int quantity)
        {
            for (int i = 0; i < quantity; i++)
                _layers.Add(new WeightedCharacterLayer(CharacterSet));
        }

        void AddWordLength(int length)
        {



            if (_wordLengths.ContainsKey(length))
                _wordLengths[length]++;

            else
                _wordLengths.Add(length, 1);
        }

        public void UpdateToStackDepth(string updateString)
        {
            if (updateString.Length > Depth)
                updateString = updateString.Substring(0, Depth);

            for (int i = 0; i < updateString.Length; i++)
                _layers[i].Update(updateString[i]);

            AddWordLength(updateString.Length);
        }

        public Dictionary<int, int> GetWordLengths() => new Dictionary<int, int>(_wordLengths);

        public List<WeightedCharacterLayer> GetLayers() => _layers; // Redo

        public string GetRandomString(int length)
        {
            if (length > Depth)
                throw new ArgumentException("Length can not be longer than stack depth", nameof(length));

            var randomString = "";

            for (int i = 0; i < length; i++)
                randomString += _layers[i].GetCharacter(_random.Next(0, _layers[i].MaxWeight));

            return randomString;
        }

        public string GetProbableLengthString()
        {
            throw new NotImplementedException();
        }

        int GetProbableLength()
        {
            throw new NotImplementedException();
        }
    }
}
