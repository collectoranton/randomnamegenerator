using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace randomnamegenerator
{
    class TripleDictionary
    {
        Dictionary<int, string> triplesVowelFirst = new Dictionary<int, string>();
        Dictionary<int, string> triplesConsonantFirst = new Dictionary<int, string>();
        Random random = new Random();
        int indexVowels = 0;
        int indexConsonants = 0;

        public TripleDictionary()
        {
            var path = @"C:\Project\CsharpExcercises\randomnamegenerator\randomnamegenerator\out.txt";
            ImportDirectory(path);
        }

        void ImportDirectory(string path)
        {
            var streamReader = new StreamReader(path);

            while (!streamReader.EndOfStream)
            {
                var stream = streamReader.ReadLine();

                if (stream.Length != 3)
                    throw new Exception("Triple in dictionary not 3 characters");

                AddTriple(stream);
            }
        }

        public void AddTriple(string triple)
        {
            if (FirstCharacterIsVowel(triple))
                AddVowel(triple);
            else
                AddConsonant(triple);
        }

        public Triple GetTriple(bool firstCharacterIsVowel)
        {
            if (firstCharacterIsVowel)
                return ParseStringToTriple(GetRandomTripleFromDictionary(triplesVowelFirst));
            else
                return ParseStringToTriple(GetRandomTripleFromDictionary(triplesConsonantFirst));                
        }

        void AddVowel(string tripleVowelFirst)
        {
            triplesVowelFirst.Add(indexVowels, tripleVowelFirst);
            indexVowels++;
        }

        void AddConsonant(string tripleConsonantFirst)
        {
            triplesConsonantFirst.Add(indexConsonants, tripleConsonantFirst);
            indexConsonants++;
        }

        string GetRandomTripleFromDictionary(Dictionary<int, string> dictionary)
        {
            var rnd = random.Next(0, dictionary.Count);
            var result = dictionary[rnd];
            return result;
        }
        Triple ParseStringToTriple(string stringToParse) => new Triple(stringToParse);

        bool FirstCharacterIsVowel(string triple) => ("eyuioa".Contains(triple[0].ToString())) ? true : false;
    }
}
