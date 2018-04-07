using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace randomnamegenerator
{
    class TextAnalyzer
    {
        public void GetChunksFromText(int chunkLength, string pattern, string inputPath, string outputPath)
        {
            var streamReader = new StreamReader(inputPath);
            StringBuilder stringBuilder = new StringBuilder(chunkLength);
            var list = new List<string>();

            while (!streamReader.EndOfStream)
            {
                while (stringBuilder.Length != chunkLength && !streamReader.EndOfStream)
                {
                    var getCharacter = (char)streamReader.Read();
                    var buffer = getCharacter.ToString().ToLower();

                    if (pattern.Contains(buffer))
                        stringBuilder.Append(buffer);
                    else
                        stringBuilder.Clear();
                }

                if (!streamReader.EndOfStream)
                {
                    list.Add(stringBuilder.ToString());
                    stringBuilder.Remove(0, 1);
                }
            }

            streamReader.Close();
            WriteWordListToFile(list, outputPath);
        }

        void WriteWordListToFile(List<string> wordList, string path)
        {
            var streamWriter = new StreamWriter(path);

            foreach (var word in wordList)
                streamWriter.WriteLine(word);

            streamWriter.Close();
        }

        public Letter GetTreeFromFile(string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);

            var letter = (Letter)formatter.Deserialize(stream);

            stream.Close();

            return letter;
        }

        public Letter TrainLetterTreeFromTextFile(string inputPath, string rejectedListPath)
        {
            // Regex ^\w+\b$

            var wordList = WordListFromFile(inputPath, Alphabet.Separators);
            WriteWordListToFile(WordListCleanUp(wordList, Alphabet.English), rejectedListPath);

            Letter tree = new Letter();
            UpdateTreeWithWordList(tree, wordList);

            return tree;
        }

        public void SaveTreeToFile(Letter root, string outputPath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);

            formatter.Serialize(stream, root);

            stream.Close();
        }

        void UpdateTreeWithWordList(Letter root, List<string> wordList)
        {
            foreach (var word in wordList)
                root.Update(word);
        }

        List<string> WordListFromFile(string path, string separators) => File.ReadAllText(path).Split(separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

        List<string> WordListCleanUp(List<string> wordList, string allowedWordCharacters)
        {
            var rejectedList = GetListWithNotAllowedWords(wordList, allowedWordCharacters);

            wordList.RemoveAll(w => rejectedList.Contains(w));

            return rejectedList;
        }

        public List<string> GetListWithNotAllowedWords(List<string> wordList, string allowedWordCharacters)
        {
            return wordList.FindAll(w => WordContainsNotAllowedCharacter(w, allowedWordCharacters));
        }

        bool WordContainsNotAllowedCharacter(string word, string allowedWordCharacters)
        {
            return word.ToLower().Any(c => !allowedWordCharacters.Contains(c));
        }
    }
}
