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
        public void GetChunksFromText(int chunkLength, string pattern, string inputPath,string outputPath)
        {
            var streamReader = new StreamReader(inputPath);
            var streamWriter = new StreamWriter(outputPath);
            StringBuilder stringBuilder = new StringBuilder(chunkLength);

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
                    streamWriter.WriteLine(stringBuilder);
                    stringBuilder.Remove(0, 1);
                }
            }

            streamReader.Close();
            streamWriter.Close();
        }

        public void TrainLetterTreeFromFile(string inputPath, string outputPath)
        {
            var wordList = WordListFromFile(inputPath);
            Letter root = new Letter();

            UpdateTreeWithWordList(root, wordList);

            SaveTreeToFile(root, outputPath);
        }

        void SaveTreeToFile(Letter root, string outputPath)
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

        List<string> WordListFromFile(string path) => File.ReadAllText(path).Split(Alphabet.Separators.ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

        List<string> WordListCleanUp(List<string> wordList, string allowedWordCharacters)
        {
            var rejectedList = new List<string>();

            for (int i = 0; i < wordList.Count; i++)
            {
                
            }

            throw new NotImplementedException();
        }
    }
}
