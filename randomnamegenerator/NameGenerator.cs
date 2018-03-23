using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    enum LanguageRule
    {
        Random
    }

    public class NameGenerator
    {
        Random random = new Random();
        bool isFirstCharacter = true;
        bool lastCharacterWasVowel;
        int length;

        public string GenerateRandomName(int maxLength = 7, int minLength = 3)
        {
            if (minLength < 2 || maxLength < 2)
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
            {
                if (isFirstCharacter)
                {
                    name = GenerateNameCharacter(true, false);
                    continue;
                }
                if (IsLastCharacter(name.Length, maxLength))
                    name += GenerateNameCharacter(false, true);
                else
                    name += GenerateNameCharacter(false, false);
            }

            isFirstCharacter = true;

            return name;
        }

        bool IsLastCharacter(int nameLength, int maxLength) => (maxLength - nameLength == 1) ? true : false;

        string GenerateNameCharacter(bool isFirstCharacter, bool isLastCharacter)
        {
            while (true)
            {
                switch (random.Next(0, 9))
                {
                    case 0:
                    case 1:
                    case 2:
                        if (isFirstCharacter)
                        {
                            this.isFirstCharacter = false;
                            return GenerateVowel().ToString().ToUpper();
                        }
                        if (!lastCharacterWasVowel && !isFirstCharacter)
                            return GenerateVowel().ToString();
                        break;
                    case 3:
                    case 4:
                    case 5:
                        if (isFirstCharacter)
                        {
                            this.isFirstCharacter = false;
                            return GenerateConsonant().ToString().ToUpper();
                        }
                        if (lastCharacterWasVowel && !isFirstCharacter)
                            return GenerateConsonant().ToString();
                        break;
                    case 6:
                    case 7:
                        if (lastCharacterWasVowel && !isFirstCharacter && !isLastCharacter)
                            return GenerateDoubleConsonant();
                        break;
                    case 8:
                        if (!lastCharacterWasVowel && !isLastCharacter)
                            return GenerateDoubleVowel(isFirstCharacter);
                        break;
                    default:
                        return null;
                }
            }
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

        char GenerateConsonant()
        {
            lastCharacterWasVowel = false;
            return GenerateCharacter("qwrtpsdfghjklzxcvbnm");
        }

        char GenerateVowel()
        {
            lastCharacterWasVowel = true;
            return GenerateCharacter("eyuioa");
        }

        char GenerateCharacter(string pattern) => pattern[random.Next(0, pattern.Length)];
    }
}
