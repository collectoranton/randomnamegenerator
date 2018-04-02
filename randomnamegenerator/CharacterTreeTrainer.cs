using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    class CharacterTreeTrainer
    {
        public void UpdateTreeWithWord(Character character, string word)
        {
            Update(character, word[0]);

            // Recursion?
        }

        public void Update(Character character, char updateChar)
        {
            if (character.IsLast)
            {
                character.IsLast = false;
                InitializeChildren(character, updateChar);
            }
            else
                UpdateCharacter(character, updateChar);
        }

        void UpdateCharacter(Character character, char characterAssign)
        {
            if (CharacterHasChild(character, characterAssign))
                character.Occurrence++;
            else
                CreateNewChild(character, characterAssign);

            UpdateChildrensLevelTotal(character);
        }

        bool CharacterHasChild(Character character, char characterAssign) => character.Children.Any(c => c.Self == characterAssign);

        void InitializeChildren(Character character, char initiationChar)
        {
            character.Children = new List<Character> { new Character(initiationChar, character) };
        }

        void CreateNewChild(Character character, char characterAssign)
        {
            character.Children.Add(new Character(characterAssign, character, character.Children.Count));
        }

        public void UpdateLevelTotal(Character character, int levelTotal)
        {
            if (character.LevelTotal == levelTotal || character.LevelTotal == levelTotal - 1)
                character.LevelTotal = levelTotal;
            else
                throw new Exception("Level total error");


        }

        void UpdateChildrensLevelTotal(Character character)
        {
            foreach (var child in character.Children)
                UpdateLevelTotal(character, character.Children.Count);
        }

        char GetFirstCharacter(string inputString) => inputString[0];

        string RestOfString(string inputString) => inputString.Substring(1);
    }
}
