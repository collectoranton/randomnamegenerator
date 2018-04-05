using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    public class Alphabet
    {
        public const string English = "abcdefghijklmnopqrstuvwxyz";
        public const string Vowels = "aeiouy";
        public const string Consonants = "bcdfghjklmnpqrstvwxz";
        public const string Separators = " ,.;:!?";
        public string Custom { get; set; }
    }
}
