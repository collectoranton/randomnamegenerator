using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    public class UI
    {
        public static void Run()
        {
            var minLength = GetMinLengthFromUser();
            var maxLength = GetMaxLengthFromUser();
            var quantity = GetNumberOfNamesFromUser();
            var rule = GetLanguageRuleFromUser();

            var nameGenerator = new NameGenerator();
            var names = new List<string>();

            for (int i = 0; i < quantity; i++)
            {
                names.Add(nameGenerator.GenerateRandomName(maxLength, minLength));
            }

            Console.WriteLine();

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();
        }

        private static int GetNumberOfNamesFromUser()
        {
            Console.Write("Enter number of names to generate: ");
            return int.Parse(Console.ReadLine());
        }

        private static int GetMaxLengthFromUser()
        {
            Console.Write("Enter maximum length: ");
            return  int.Parse(Console.ReadLine());
        }

        private static int GetMinLengthFromUser()
        {
            Console.Write("Enter minimum length: ");
            return  int.Parse(Console.ReadLine());
        }

        static LanguageRule GetLanguageRuleFromUser()
        {
            var cursorLeft = Console.CursorLeft;
            var counter = 1;

            foreach (var rule in Enum.GetNames(typeof(LanguageRule)))
            {
                Console.SetCursorPosition(cursorLeft, Console.CursorTop);
                Console.WriteLine($"[{counter}] {rule}");
                counter++;
            }

            Console.Write("Choose cultural language rule: ");

            return (LanguageRule)int.Parse(Console.ReadLine()) - 1;
        }
    }
}
