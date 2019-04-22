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
        [InlineData("kjhkjh", "kjhkjh")]
        public void LoadAvailableTest_TestingForErrors(string dir, string fileEX)
        {
            String[] expected = {"Error"};
            Assert.NotEqual<String>(expected, Model.LoadAvailableTest(dir, fileEX));
        }

        
    }
}
