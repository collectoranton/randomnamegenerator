﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace randomnamegenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            //UI.Run();

            //Random random = new Random();
            //var textAnalyzer = new TextAnalyzer();
            //var nameGenerator = new NameGenerator();

            //var stack = textAnalyzer.TrainWeightedCharacterStackFromTextFile(Alphabet.English, "treetest.txt", "rejected.txt");

            //for (int i = 0; i < 10000; i++)
            //stack.Update(nameGenerator.GenerateRandomName(3, 2).ToLower());

            //for (int i = 0; i < 100; i++)
            //{
            //    stack.Update("abc");
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    foreach (var item in stack.GetLayers()[i]._layer)
            //        Console.WriteLine($"{item.Key} {item.WeightIndex}");
            //}

            //Console.WriteLine($"stack.Depth '{stack.Depth}' - stack.CharacterSet '{stack.CharacterSet}'");
            //var dictionary = stack.GetWordLengths();
            //var list = dictionary.Keys.ToList();
            //list.Sort();

            //foreach (var item in dictionary)
            //{
            //    Console.WriteLine($"Length: {item.Key}, Count: {item.Value}");
            //}

            //foreach (var item in list)
            //{
            //    Console.WriteLine($"Length: {item}, Count: {dictionary[item]}");
            //}

            //Console.WriteLine($"stack.layers[0].Count '{stack.layers[0].Count}'" +
            //    $"- stack.layers[0].MaxWeight '{stack.layers[0].MaxWeight}'" +
            //    $"- stack.layers[0].Weights[25].WeightIndex '{stack.layers[0].Weights[25].WeightIndex}'");

            //for (int i = 0; i < 100; i++)
            //{
            //    //Console.WriteLine(stack.GetRandomString(random.Next(2, stack.Depth + 1)));
            //    Console.WriteLine(stack.GetProbableLengthString());
            //}

            var textAnalyzer = new TextAnalyzer();
            //var path = @"C:\Project\CsharpExcercises\randomnamegenerator\randomnamegenerator\";
            var path = @"C:\Users\Anton\Source\Repos\randomnamegenerator\randomnamegenerator\";

            var root = textAnalyzer.TrainLetterTreeFromTextFile(path + "treetest.txt", path + "tree3.txt");
            //textAnalyzer.GetChunksFromText(3, Letters.EnglishAlphabet, path + "text.txt", path + "out.txt");

            //var root = textAnalyzer.GetTreeFromFile(path + "tree2.bin");

            var rnd = new Random();
            var next = 0;

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine($"{root.GetNextRandomCharacter(next = rnd.Next(3, 20))} - Count: {next}");
            }

            //var nameGenerator = new NameGenerator();
            //var names = new List<string>();
            //var counter = 0;
            //var counter3 = 0;
            //var counter4 = 0;
            //var counter5 = 0;
            //var counter6 = 0;
            //var counter7 = 0;
            //var counter8 = 0;

            //for (int i = 0; i < 10000; i++)
            //{
            //    //Console.WriteLine(nameGenerator.GenerateRandomName());
            //    names.Add(nameGenerator.GenerateRandomName(7, 7));
            //}

            //foreach (var name in names)
            //{
            //    var hit = false;
            //    foreach (var character in name)
            //    {
            //        if ("*".Contains(character.ToString()))
            //            hit = true;   
            //    }
            //    if (hit)
            //        counter++;
            //}

            //foreach (var item in names)
            //{
            //    if (item.Length == 3)
            //        counter++;
            //    if (item.Length == 3)
            //        counter3++;
            //    if (item.Length == 4)
            //        counter4++;
            //    if (item.Length == 5)
            //        counter5++;
            //    if (item.Length == 6)
            //        counter6++;
            //    if (item.Length == 7)
            //        counter7++;
            //    if (item.Length == 8)
            //        counter8++;
            //}

            //while (true)
            //{
            //    if (nameGenerator.GenerateRandomName() == "Anton")
            //        break;
            //    if (counter == int.MaxValue)
            //        Console.WriteLine("Overflow");
            //    counter++;
            //}

            //Console.WriteLine(counter);
            //Console.WriteLine(counter3);
            //Console.WriteLine(counter4);
            //Console.WriteLine(counter5);
            //Console.WriteLine(counter6);
            //Console.WriteLine(counter7);
            //Console.WriteLine(counter8);
        }
    }
}
