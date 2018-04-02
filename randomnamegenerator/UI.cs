using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    public class UI
    {
        public static void Run()
        {
            string tripleDictionaryPath = @"out.txt";

            Console.Write("Use triples? (y/n) ");
            if (Console.ReadLine() == "y")
            {
                Console.Write("Train triple dictionary? (y/n) ");
                if (Console.ReadLine() == "y")
                    tripleDictionaryPath = TrainTripleDictionary();

                GenerateRandomName(tripleDictionaryPath, true);
            }
            else
                GenerateRandomName(tripleDictionaryPath, false);
        }

        private static string TrainTripleDictionary()
        {
            Console.Write("Enter file to train from: ");
            var inputPath = Console.ReadLine();

            Console.Write("Enter file to save to: ");
            var outputPath = Console.ReadLine();

            var textAnalyzer = new TextAnalyzer();
            textAnalyzer.GetChunksFromText(3, Alphabet.English, inputPath, outputPath);

            return outputPath;
        }

        private static void GenerateRandomName(string tripleDictionaryPath, bool useTriples)
        {
            var minLength = GetMinLengthFromUser();
            var maxLength = GetMaxLengthFromUser();
            var quantity = GetNumberOfNamesFromUser();
            //var rule = GetLanguageRuleFromUser();

            NameGenerator nameGenerator;

            if (useTriples)
                nameGenerator = new NameGenerator(tripleDictionaryPath);
            else
                nameGenerator = new NameGenerator();

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
