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
        Random random = new Random();

        public char Character { get; private set; }
        public Letter Parent { get; private set; }
        public double Probability { get => Occurrence / LevelTotal; }
        public int Occurrence { get; private set; } = 1;
        public int Level { get; private set; }
        public int LevelTotal { get; private set; }
        public bool IsLast { get; private set; }

        public Letter()
        {
            Level = 0;
            IsLast = true;
        }

        public Letter(char character, Letter parent, int level, int levelTotal, string initiationString)
        {
            Character = character;
            Parent = parent;
            Level = level;
            LevelTotal = levelTotal;

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
            Occurrence++;

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
            if (LevelTotal == levelTotal || LevelTotal == levelTotal - 1)
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
            children = new List<Letter> { CreateNewChild(initiationString) };
            UpdateChildrensLevelTotal();
        }

        Letter CreateNewChild(string initiationString)
        {
            var character = GetFirstCharacter(initiationString);
            var parent = this;
            var level = Level + 1;
            var levelTotal = (children == null) ? 1 : children.Count;
            var _initiationString = RestOfString(initiationString);
            return new Letter(character, parent, level, levelTotal, _initiationString);
        }

        void UpdateChildrensLevelTotal()
        {
            foreach (var child in children)
                child.UpdateLevelTotal(children.Count);
        }

        char GetFirstCharacter(string inputString) => inputString[0];

        string RestOfString(string inputString) => inputString.Substring(1);


        string ReturnRandomString(int depth)
        {
            throw new NotImplementedException();
        }

        public string GetNextRandomCharacter(int index)
        {
            if (IsLast || index == 1)
                return Character.ToString();
            else
                return Character + NextRandomChild().GetNextRandomCharacter(index - 1);
        }

        Letter NextRandomChild()
        {
            var chosen = random.Next(1, children.Count + 1);
            var occurrance = 0;

            foreach (var child in children)
            {
                occurrance += child.Occurrence;

                if (occurrance <= chosen)
                    return child;
            }

            throw new Exception("Failed to find next random child");
        }
    }
}
