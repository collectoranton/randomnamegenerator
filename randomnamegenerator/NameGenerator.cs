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
                name += GenerateNameCharacter(length - name.Length);

            isFirstCharacter = true;

            return name;
        }

        string GenerateNameCharacter(int charactersLeft)
        {
            while (true)
            {
                switch (random.Next(0, 9))
                {
                    case 0:
                    case 1:
                    case 2:
                        if (!lastCharacterWasVowel)
                            return GenerateVowel();
                        break;
                    case 3:
                    case 4:
                    case 5:
                        if (lastCharacterWasVowel)
                            return GenerateConsonant();
                        break;
                    case 6:
                    case 7:
                        if (lastCharacterWasVowel && !isFirstCharacter && charactersLeft > 1)
                            return GenerateDoubleConsonant();
                        break;
                    case 8:
                        if (!lastCharacterWasVowel && charactersLeft > 1)
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

        string GenerateConsonant()
        {
            lastCharacterWasVowel = false;
            return FormattedForFirstCharacter(GenerateCharacter("qwrtpsdfghjklzxcvbnm"));
        }

        string GenerateVowel()
        {
            lastCharacterWasVowel = true;
            return FormattedForFirstCharacter(GenerateCharacter("eyuioa"));
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
