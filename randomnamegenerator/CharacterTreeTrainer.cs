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
        }

        bool CharacterHasChild(Character character, char characterAssign) => character.Children.Any(c => c.Self == characterAssign);

        void InitializeChildren(Character character, char initiationChar)
        {
            character.Children = new List<Character> { new Character(initiationChar, character) };
        }

        void CreateNewChild(Character parent, char characterAssign)
        {
            parent.Children.Add(new Character(characterAssign, parent));
        }

        char GetFirstCharacter(string inputString) => inputString[0];

        string RestOfString(string inputString) => inputString.Substring(1);
    }
}
