using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    class Triple
    {
        public string TripleString { get; }
        public bool LastCharacterIsVowel { get; }

        public Triple(string triple)
        {
            TripleString = triple.ToLower();
            LastCharacterIsVowel = DetermineLastCharacterCase(triple);
        }

        static bool DetermineLastCharacterCase(string triple) => ("eyuioa".Contains(triple[2].ToString())) ? true : false;
    }
}
