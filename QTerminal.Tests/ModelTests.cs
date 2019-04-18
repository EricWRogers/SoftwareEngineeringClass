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
        [InlineData("./Test", "test", "Error")]
        [InlineData("./StudentAnswer", "testAnswer", "Error")]
        [InlineData("kjhkjh", "kjhkjh", "ukjh")]
        public void LoadAvailableTest_TestingError(string dir, string fileEX, string error)
        {
            String[] expected = {error};
            Assert.Equal<String>(expected, Model.LoadAvailableTest(dir, fileEX));
        }
    }
}
