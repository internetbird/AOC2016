using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models.ScrambleCommands;
using AOC2016.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Tests
{
    [TestClass]
    public class Day21Tests
    {
        [TestMethod]
        public void TestSwapPositionCommand()
        {
            var command = new SwapPositionCommand(new object[] { 4, 0 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("ebcda", output);
        }

        [TestMethod]
        public void TestSwapLetterCommand()
        {
            var command = new SwapLetterCommand(new object[] { 'd', 'b' });

            string input = "ebcda";
            string output = command.Execute(input);

            Assert.AreEqual("edcba", output);
        }

        [TestMethod]
        public void TestRotateCommand1()
        {
            var command = new RotateCommand(new object[] { "left", 1 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("bcdea", output);
        }

        [TestMethod]
        public void TestRotateCommand2()
        {
            var command = new RotateCommand(new object[] { "right", 1});

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("eabcd", output);
        }

        [TestMethod]
        public void TestRotateCommand3()
        {
            var command = new RotateCommand(new object[] { "left", 6});

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("bcdea", output);
        }

        [TestMethod]
        public void TestRotateCommand4()
        {
            var command = new RotateCommand(new object[] { "right", 3 });

            string input = "abcde";
            string output = command.Execute(input);

            Assert.AreEqual("cdeab", output);
        }
    }
}
