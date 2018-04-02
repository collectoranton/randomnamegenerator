using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    public class Alphabet
    {
        public const string English = "eyuioaqwrtpsdfghjklzxcvbnm";
        public const string Vowels = "eyuioa";
        public const string Consonants = "qwrtpsdfghjklzxcvbnm";
        public const string Separators = " ,.;:!?";
        public string Custom { get; set; }
    }
}
