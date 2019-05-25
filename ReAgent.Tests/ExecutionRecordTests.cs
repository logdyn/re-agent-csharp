using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReAgent.Tests
{
    class TestCommand : ICommand
    {
        private string name;

        public TestCommand() : this("Test Command") { }
        public TestCommand(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }
    }

    [TestClass]
    public class ExecutionRecordTests
    {
        [TestMethod]
        public void CompareTo_Timestamp()
        {
            ExecutionRecord first = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.DO, 1);
            ExecutionRecord second = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.DO, 2);
            ExecutionRecord third = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.DO, 2);

            Assert.AreEqual(-1, first.CompareTo(second));
            Assert.AreEqual(1, second.CompareTo(first));
            Assert.AreEqual(0, second.CompareTo(third));
        }

        [TestMethod]
        public void CompareTo_Name()
        {
            ExecutionRecord first = new ExecutionRecord(new TestCommand("ABC"), ExecutionRecord.Operations.DO, 1);
            ExecutionRecord second = new ExecutionRecord(new TestCommand("DEF"), ExecutionRecord.Operations.DO, 1);
            ExecutionRecord third = new ExecutionRecord(new TestCommand("DEF"), ExecutionRecord.Operations.DO, 1);

            Assert.AreEqual(-1, first.CompareTo(second));
            Assert.AreEqual(1, second.CompareTo(first));
            Assert.AreEqual(0, second.CompareTo(third));
        }

        [TestMethod]
        public void CompareTo_Operation()
        {
            ExecutionRecord first = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.DO, 1);
            ExecutionRecord second = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.UNDO, 1);
            ExecutionRecord third = new ExecutionRecord(new TestCommand(), ExecutionRecord.Operations.UNDO, 1);

            Assert.AreEqual(-1, first.CompareTo(second));
            Assert.AreEqual(1, second.CompareTo(first));
            Assert.AreEqual(0, second.CompareTo(third));
        }
    }
}
