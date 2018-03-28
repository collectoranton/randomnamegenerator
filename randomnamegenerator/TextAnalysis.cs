using System;
using System.Collections.Generic;
using System.Text;

namespace randomnamegenerator
{
    class TextAnalysis
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string Source { get; set; }
        public DateTime TimeCreated { get; set; }
        public TimeSpan TimeTaken { get; set; }
        public int NumberOfWordsAnalyzed { get; set; }
        public int ShortestWord { get; set; }
        public int LongestWord { get; set; }
        public int NumberOfLettersUsed { get; set; }
        public int MyProperty { get; set; }
    }
}
