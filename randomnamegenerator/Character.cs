using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    [Serializable]
    class Character
    {
        public char Self { get; private set; }
        public Character Parent { get; private set; }
        public List<Character> Children { get; set; } // Initialisation?
        public int Occurrence { get; set; } = 1;
        public bool IsLast { get; set; }
        public int LevelTotal { get => (Parent != null) ? Parent.Children.Count : 0; }
        public double Probability { get => Occurrence / LevelTotal; }

        public Character()
        {
        }

        public Character(char self, Character parent, bool isLast = true)
        {
            Self = self;
            Parent = parent;
            IsLast = isLast;
        }
    }
}
