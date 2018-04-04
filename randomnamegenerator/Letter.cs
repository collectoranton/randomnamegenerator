using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace randomnamegenerator
{
    [Serializable]
    class Letter
    {
        Random random = new Random();

        public char Character { get; private set; }
        public Letter Parent { get; private set; }
        public List<Letter> Children { get; set; }
        public int Occurrence { get; private set; } = 1;
        public int Level { get; private set; }
        public int LevelTotal { get => (Parent != null) ? Parent.Children.Count : 0; }
        public bool IsLast { get; private set; }
        public double Probability { get => Occurrence / LevelTotal; }

        public Letter()
        {
            Level = 0;
            IsLast = true;
        }

        public Letter(char character, Letter parent, int level, string initiationString)
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

        void UpdateChildren(string updateString)
        {
            var existingChild = Children.FirstOrDefault(child => child.Character == FirstCharacter(updateString));

            if (existingChild == null)
                Children.Add(CreateNewChild(updateString));
            else
                existingChild.Update(RestOfString(updateString));
        }

        void InitializeChildren(string initiationString)
        {
            Children = new List<Letter> { CreateNewChild(initiationString) };
        }

        Letter CreateNewChild(string initiationString)
        {
            var character = FirstCharacter(initiationString);
            var parent = this;
            var level = Level + 1;
            var restOfInitiationString = RestOfString(initiationString);
            return new Letter(character, parent, level, restOfInitiationString);
        }

        char FirstCharacter(string inputString) => inputString[0];

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
            var chosen = random.Next(1, Children.Count + 1);
            var occurrance = 0;

            foreach (var child in Children)
            {
                occurrance += child.Occurrence;

                if (occurrance <= chosen)
                    return child;
            }

            throw new Exception("Failed to find next random child");
        }
    }
}
