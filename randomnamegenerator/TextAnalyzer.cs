using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace randomnamegenerator
{
    class TextAnalyzer
    {
        StreamReader streamReader;
        StreamWriter streamWriter;

        public TextAnalyzer()
        {

        }

        public void GetChunksFromText(int chunkLength, string pattern, string inputPath,string outputPath)
        {
            streamReader = new StreamReader(inputPath);
            streamWriter = new StreamWriter(outputPath);
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
            streamReader = new StreamReader(inputPath);

            Letter root = new Letter();

            root

            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(outputPath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, root);
            stream.Close();
        }
    }
}
