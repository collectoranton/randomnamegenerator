﻿using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    enum LanguageRule
    {
        Random,
        RandomOnlySingles,
        RandomOnlySingleVowels,
        RandomOnlySingleConsonants,
        RandomNoTriples,
        Custom
    }

    public class NameGenerator
    {
        TripleDictionary tripleDictionary;
        Random random = new Random();
        bool isFirstCharacter = true;
        bool lastCharacterWasVowel;
        bool useTriples;
        int length;

        public NameGenerator()
        {

        }

        public NameGenerator(string tripleDictionaryPath)
        {
            tripleDictionary = new TripleDictionary(tripleDictionaryPath);
            useTriples = true;
        }


        public string GenerateNameFromTree()
        {
            throw new NotImplementedException();
        }



        public string GenerateRandomName(int maxLength = 7, int minLength = 3)
        {
            if (minLength < 2)
                throw new ArgumentException("Name can not be shorter than 2 letters.");
            if (maxLength < minLength)
                throw new ArgumentException("minLength can not be less than maxLength.");

            return GenerateName(maxLength, minLength);
        }

        string GenerateName(int maxLength, int minLength)
        {
            length = random.Next(minLength, maxLength + 1);
            string name = "";

            while (name.Length < length)
                name += GenerateNameCharacters(length - name.Length);

            isFirstCharacter = true;

            return name;
        }

        string GenerateNameCharacters(int charactersLeft)
        {
            while (true)
            {
                var chance = random.Next(0, 10);

                if (chance <= 2)
                {
                    if (!lastCharacterWasVowel)
                        return GenerateVowel();
                }

                else if (chance > 2 && chance <= 5)
                {
                    if (lastCharacterWasVowel)
                        return GenerateConsonant();
                }

                else if (chance > 5 && chance <= 7)
                {
                    if (lastCharacterWasVowel && !isFirstCharacter && charactersLeft > 1)
                        return GenerateDoubleConsonant();
                }

                else if (chance == 8)
                {
                    if (!lastCharacterWasVowel && charactersLeft > 1)
                        return GenerateDoubleVowel(isFirstCharacter);
                }

                else if (chance == 9)
                {
                    if (useTriples && !isFirstCharacter && charactersLeft > 2)
                        return GetRandomTriple();
                }

                else
                    return null;
            }
        }

        string GetRandomTriple()
        {
            var triple = tripleDictionary.GetTriple(!lastCharacterWasVowel);

            lastCharacterWasVowel = triple.LastCharacterIsVowel;

            return triple.TripleString;
        }

        string GenerateDoubleVowel(bool isFirstCharacter)
        {
            string doubleVowel;
            if (isFirstCharacter)
            {
                this.isFirstCharacter = false;
                doubleVowel = GenerateVowel().ToString().ToUpper();
            }
            else
                doubleVowel = GenerateVowel().ToString();
            doubleVowel += GenerateVowel().ToString();
            return doubleVowel;
        }

        string GenerateDoubleConsonant()
        {
            string doubleConsonant = GenerateConsonant().ToString();
            doubleConsonant += GenerateConsonant().ToString();
            return doubleConsonant;
        }

        string GenerateConsonant()
        {
            lastCharacterWasVowel = false;
            return FormattedForFirstCharacter(GenerateCharacter(Alphabet.Consonants));
        }

        string GenerateVowel()
        {
            lastCharacterWasVowel = true;
            return FormattedForFirstCharacter(GenerateCharacter(Alphabet.Vowels));
        }

        string FormattedForFirstCharacter(string character)
        {
            if (isFirstCharacter)
            {
                isFirstCharacter = false;
                return character.ToUpper();
            }
            return character;
        }

        string GenerateCharacter(string pattern) => pattern[random.Next(0, pattern.Length)].ToString();
    }
}
