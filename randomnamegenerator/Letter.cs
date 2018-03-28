using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    [Serializable]
    class Letter
    {
        List<Letter> children;

        int occurrence = 1;
        public char Character { get; private set; }
        public char Parent { get; private set; }
        public double Probability { get => occurrence / LevelTotal; }
        public int Level { get; private set; }
        public int LevelTotal { get; private set; }
        public bool IsLast { get; private set; }

        public Letter()
        {
            Level = 0;
            IsLast = true;
        }

        public Letter(char character, char parent, int level, string initiationString)
        {
            Character = character;
            Parent = parent;
            Level = level;

            if (initiationString.Length == 1)
                IsLast = true;
            else
            {
                IsLast = false;
                InitializeChildren(initiationString);
            }
        }

        public void Update(string updateString)
        {
            occurrence++;

            if (updateString.Length == 1)
                return;

            if (IsLast)
            {
                IsLast = false;
                InitializeChildren(updateString);
            }
            else
                UpdateChildren(updateString);
        }

        public void UpdateLevelTotal(int levelTotal)
        {
            if (LevelTotal == levelTotal - 1)
                LevelTotal = levelTotal;
            else
                throw new Exception("Level total error");
        }

        void UpdateChildren(string updateString)
        {
            var existingChild = children.FirstOrDefault(child => child.Character == GetFirstCharacter(updateString));

            if (existingChild == null)
                children.Add(CreateNewChild(updateString));
            else
                existingChild.Update(RestOfString(updateString));

            UpdateChildrensLevelTotal();
        }

        void InitializeChildren(string initiationString)
        {
            children = new List<Letter>();
            children.Add(CreateNewChild(initiationString));
            UpdateChildrensLevelTotal();
        }

        Letter CreateNewChild(string initiationString)
        {
            var character = GetFirstCharacter(initiationString);
            var parent = Character;
            var level = Level + 1;
            var _initiationString = RestOfString(initiationString);
            return new Letter(character, parent, level, _initiationString);
        }

        void UpdateChildrensLevelTotal()
        {
            foreach (var child in children)
                child.UpdateLevelTotal(children.Count);
        }

        char GetFirstCharacter(string inputString) => inputString[0];

        string RestOfString(string inputString) => inputString.Substring(1);
    }
}
