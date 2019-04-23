using System;
using System.IO;
using System.Collections;
using QTerminal;
using Xunit;

namespace QTerminal.Tests
{
    public class ModelTests
    {
        [Theory]
        [InlineData("../../../../QTerminal/Test", "test")]
        [InlineData("../../../../QTerminal/StudentAnswer", "testAnswer")]
        public void LoadAvailableTest_TestingForErrors(string dir, string fileEX)
        {
            String[] expected = {"Error"};
            Assert.NotEqual<String>(expected, Model.LoadAvailableTest(dir, fileEX));
        }

        [Theory]
        [InlineData("../../../../QTerminal/StudentAnswer","Justin", "testAnswer")]
        [InlineData("../../../../QTerminal/StudentAnswer","Test", "testAnswer")]
        [InlineData("../../../../QTerminal/StudentAnswer","UnitTest", "testAnswer")]
        public void SaveTest(string dir,string fileName, string fileEx)
        {
            Test test = new Test();
            string path = dir + "/" + fileName + "." + fileEx;

            Model.SaveTest(test, dir, fileName, fileEx);
            Assert.True(System.IO.File.Exists(path));
            System.IO.File.Delete(path);
        }

        [Theory]
        [InlineData("Justin")]
        [InlineData("UnitTesting")]
        [InlineData("Test")]
        public void makeFolder(string FolderName)
        {
            Model.makeFolder(FolderName);

            string path = "./" + FolderName;
            
            Assert.True(System.IO.Directory.Exists(path));
            System.IO.Directory.Delete(path);
        }

        [Theory]
        [InlineData("Justin", "UnitTest", ".TEST", "Justin")]
        public void LoadTestNames(string testName, string dirName, string extension, string excepted)
        {
            Test test = new Test();
            Model.SaveTest(test, dirName, testName, extension);

            string[] testFileNames = {testName};
            string[] exceptedOutcomes = {excepted};

            Assert.Equal(exceptedOutcomes, Model.LoadTestNames(testFileNames, dirName, extension));
        }
    }
}
