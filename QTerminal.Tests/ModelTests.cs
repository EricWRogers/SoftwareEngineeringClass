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
        //[InlineData("../../../../QTerminal/Test", "test", "Error")]
        //[InlineData("../../../../QTerminal/StudentAnswer", "testAnswer")]
        //[InlineData("kjhkjh", "kjhkjh", "ukjh")]
        public void LoadAvailableTest_TestingError()
        {
            Model model = new Model();
            Action act = () => Model.LoadAvailableTest("../", "test");
            Assert.Throws<Exception>(act);
        }
    }
}
