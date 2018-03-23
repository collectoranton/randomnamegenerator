using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace NameGenerator.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FirstLetterIsUpperCase()
        {
            var list = GenerateListOfNames(7, 3, 10000);

            foreach (var name in list)
                Assert.IsTrue(char.IsUpper(name[0]));
        }

        [TestMethod]
        public void OtherLettersAreLowerCase()
        {
            var list = GenerateListOfNames(7, 3, 10000);

            foreach (var name in list)
            {
                for (int i = 1; i < name.Length; i++)
                {
                    Assert.IsTrue(char.IsLower(name[i]));
                }
            }
        }

        [TestMethod]
        public void NamesAreWithinRange()
        {
            var list = GenerateListOfNames(7, 3, 10000);

            foreach (var name in list)
            {
                for (int i = 1; i < name.Length; i++)
                {
                    Assert.IsTrue(name.Length >= 3 && name.Length <= 7);
                }
            }
        }

        [TestMethod]
        public void NamesAreCorrectLength2()
        {
            const int nameLength = 2;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
        }

        [TestMethod]
        public void NamesAreCorrectLength3()
        {
            const int nameLength = 3;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
        }

        [TestMethod]
        public void NamesAreCorrectLength4()
        {
            const int nameLength = 4;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
        }

        [TestMethod]
        public void NamesAreCorrectLength5()
        {
            const int nameLength = 5;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
        }

        [TestMethod]
        public void NamesAreCorrectLength6()
        {
            const int nameLength = 6;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
        }

        [TestMethod]
        public void NamesAreCorrectLength7()
        {
            const int nameLength = 7;

            var list = GenerateListOfNames(nameLength, nameLength, 10000);

            foreach (var name in list)
                Assert.AreEqual(name.Length, nameLength);
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
