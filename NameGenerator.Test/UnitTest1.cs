using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using randomnamegenerator;

namespace NameGenerator.Test
{
    [TestClass]
    public class UnitTest1
    {
        List<string> averageList = new List<string>();

        [TestInitialize]
        public void TestInitialize()
        {
            averageList = GenerateListOfNames(7, 3, 10000);
        }

        [TestMethod]
        public void FirstLetterIsUpperCase()
        {
            foreach (var name in averageList)
                Assert.IsTrue(char.IsUpper(name[0]));
        }

        [TestMethod]
        public void OtherLettersAreLowerCase()
        {
            foreach (var name in averageList)
            {
                for (int i = 1; i < name.Length; i++)
                {
                    Assert.IsTrue(char.IsLower(name[i]));
                }
            }
        }

        [TestMethod]
        public void Max3VowelsInARow() => Assert.IsTrue(MaxLettersInARowFromPattern(3, Letters.Vowels));

        [TestMethod]
        public void Max3ConsonantsInARow() => Assert.IsTrue(MaxLettersInARowFromPattern(3, Letters.Consonants));

        [TestMethod]
        public void NamesAreWithinRange()
        {
            foreach (var name in averageList)
            {
                for (int i = 1; i < name.Length; i++)
                {
                    Assert.IsTrue(name.Length >= 3 && name.Length <= 7);
                }
            }
        }

        [TestMethod]
        public void NamesAreCorrectLength2() => Assert.IsTrue(NamesAreSetLength(2));

        [TestMethod]
        public void NamesAreCorrectLength3() => Assert.IsTrue(NamesAreSetLength(3));

        [TestMethod]
        public void NamesAreCorrectLength4() => Assert.IsTrue(NamesAreSetLength(4));

        [TestMethod]
        public void NamesAreCorrectLength5() => Assert.IsTrue(NamesAreSetLength(5));

        [TestMethod]
        public void NamesAreCorrectLength6() => Assert.IsTrue(NamesAreSetLength(6));

        [TestMethod]
        public void NamesAreCorrectLength7() => Assert.IsTrue(NamesAreSetLength(7));

        [TestMethod]
        public void NamesAreCorrectLength8() => Assert.IsTrue(NamesAreSetLength(8));

        [TestMethod]
        public void NamesAreCorrectLength9() => Assert.IsTrue(NamesAreSetLength(9));

        [TestMethod]
        public void NamesAreCorrectLength10() => Assert.IsTrue(NamesAreSetLength(10));

        bool MaxLettersInARowFromPattern(int maxNumberOfLetters, string pattern)
        {
            foreach (var name in averageList)
            {
                var counter = 0;
                foreach (var character in name)
                {
                    if (pattern.Contains(character.ToString()))
                        counter++;
                    else
                        counter--;

                    if (counter > maxNumberOfLetters)
                        return false;
                }
            }

            return true;
        }

        static bool NamesAreSetLength(int nameLength)
        {
            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                if (name.Length != nameLength)
                    return false;
            return true;
        }

        static List<string> GenerateListOfNames(int maxLength, int minLength, int numberOfNames)
        {
            var nameGenerator = new randomnamegenerator.NameGenerator();
            var nameList = new List<string>();

            for (int i = 0; i < numberOfNames; i++)
                nameList.Add(nameGenerator.GenerateRandomName(maxLength, minLength));

            return nameList;
        }
    }
}
